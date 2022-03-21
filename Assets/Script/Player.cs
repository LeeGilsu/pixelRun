using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float h_Axis;
    float v_Axis;
    public float m_MoveSpeed = 10.0f;
    Vector3 moveVec;
    bool wDown;
    bool jDown;
    public bool IsJump;

    public float MaxHP = 1;

    public float m_JumpPow = 25.0f;
    public int p_Point = 0;

    public GameObject joystick; //조이스틱 컴포넌트 가져오기위해 사용.

    Rigidbody rigid;
    Animator anim;
    AudioManager audioManager;
    
    public Vector3 forceDirection;
    //클리어 시 캐릭터 중지를 위한 bool
    public bool current_State;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        current_State = false; // false일때 정상작동.
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update() //키보드모드 
    {
        if (p_Point <= 0 && current_State == false)
        {
            GetInput();
            PlayerMove();
            Jump();
        }
        
    }
    void GetInput() //키보드모드
    {
        h_Axis = Input.GetAxisRaw("Horizontal");
        v_Axis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }
    void PlayerMove() //키보드모드
    {
        moveVec = new Vector3(h_Axis, 0, v_Axis).normalized;

        this.transform.position += moveVec * m_MoveSpeed * (wDown ? 3.0f : 1.5f) * Time.deltaTime;
        anim.SetBool("IsRun", moveVec != Vector3.zero);
        anim.SetBool("IsWalk", wDown);
        // 삼항 연산자 wDown이 ? 트루면 0.3f /  false 면 1.0f의 속도.
        transform.LookAt(transform.position + moveVec); // Rotation
    }
    void Jump() //키보드모드
    {
        if (jDown &&!IsJump)
        {
            audioManager.PlaySFX("Jump"); //점프 사운드 출력
            rigid.AddForce(Vector3.up * m_JumpPow, ForceMode.Impulse); //ForceMode.Impulse = 즉발
            anim.SetBool("IsJump",true);
            anim.SetTrigger("DoJump");
            IsJump = true;
        }
    }
    private void OnCollisionEnter(Collision collision) //키보드모드
    {
        
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("IsJump", false);
            m_JumpPow = 25.0f;
            IsJump = false;

            joystick.GetComponent<JoyStick>().IsJump = false; //조이스틱조작을 위해 false값으로 변환
        }
        if (collision.gameObject.tag == "EndGround" || collision.gameObject.tag == "Misail")
        {
            anim.SetTrigger("IsDie");
            MaxHP = 0;
        }
        if (collision.gameObject.tag == "JumpShot")
        {
            /*m_JumpPow = 40f;
            IsJump = false;

            joystick.GetComponent<JoyStick>().IsJump = false;*/
            rigid.AddForce(new Vector3(0,40f,0), ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "ProPeller")
        {
            rigid.AddForce(new Vector3(Random.Range(-1,1), 1f, -0.7f) * 30f, ForceMode.Impulse);
            // Rigibody Addforce를 이용해 콜라이더 충돌 시 뒤로 밀려남 효과 적용.
        }
        if (collision.gameObject.tag == "Push_Hammer")
        {
            rigid.AddForce(new Vector3(0, 1f, -60f), ForceMode.Impulse);
            anim.SetTrigger("IsDie");
            StartCoroutine(delayExit(1));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "exception")
        {
            IsJump = true; 
            joystick.GetComponent<JoyStick>().IsJump = true;
            rigid.freezeRotation = false;
            current_State = true; // 작동중지 _ 
            anim.SetTrigger("DoStop");

        }
    }

    IEnumerator delayExit(float i)
    {
        yield return new WaitForSeconds(i);
        MaxHP = 0;
    }
}
