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


    Rigidbody rigid;
    Animator anim;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p_Point == 0)
        {
            GetInput();
            PlayerMove();
            Jump();
        }
    }
    void GetInput()
    {
        h_Axis = Input.GetAxisRaw("Horizontal");
        v_Axis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }
    void PlayerMove()
    {
        moveVec = new Vector3(h_Axis, 0, v_Axis).normalized;

        this.transform.position += moveVec * m_MoveSpeed * (wDown ? 3.0f : 1.5f) * Time.deltaTime;
        anim.SetBool("IsRun", moveVec != Vector3.zero);
        anim.SetBool("IsWalk", wDown);
        // 삼항 연산자 wDown이 ? 트루면 0.3f /  false 면 1.0f의 속도.
        transform.LookAt(transform.position + moveVec); // Rotation
    }
    void Jump()
    {
        if (jDown &&!IsJump)
        {
            rigid.AddForce(Vector3.up * m_JumpPow, ForceMode.Impulse); //ForceMode.Impulse = 즉발
            anim.SetBool("IsJump",true);
            anim.SetTrigger("DoJump");
            IsJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("IsJump", false);
            m_JumpPow = 25.0f;
            IsJump = false;
        }

        if (collision.gameObject.tag == "EndGround" || collision.gameObject.tag == "Misail")
        {
            anim.SetTrigger("IsDie");
            MaxHP = 0;
        }
        if (collision.gameObject.tag == "JumpShot")
        {
            m_JumpPow = 50f;
            IsJump = false;
        }

    }
}
