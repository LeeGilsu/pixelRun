using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour,IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform pad;

    public Transform Player;
    Vector3 move;
    public float moveSpeed;

    [SerializeField]
    private Animator anim;
    private Rigidbody rigi;

    public bool IsJump;
    float m_JumpPow;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);

        move = new Vector3(transform.localPosition.x, 0, transform.localPosition.y).normalized;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine("PlayerMove");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
        move = Vector3.zero;
        StopCoroutine("PlayerMove");
    } 

    IEnumerator PlayerMove()
    {
        while (true)
        {
            Player.Translate(move * moveSpeed * Time.deltaTime, Space.World);
            anim.SetBool("IsRun", move != Vector3.zero);

            if (move != Vector3.zero)
            {
                Player.rotation = Quaternion.Slerp(Player.rotation, Quaternion.LookRotation(move), 10 * Time.deltaTime);
            }

            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pad = GameObject.Find("ComtrollPad").GetComponent<RectTransform>();
        Player = GameObject.Find("Player").GetComponentInChildren<Transform>();
        anim = Player.GetComponentInChildren<Animator>();
        rigi = Player.GetComponent<Rigidbody>();
        moveSpeed = 15f;
    }

    public void Jump()
    {
        Debug.Log("jumpClikc");
        if (!IsJump)
        {
            m_JumpPow = 25f;
            rigi.AddForce(Vector3.up * m_JumpPow, ForceMode.Impulse); //ForceMode.Impulse = 즉발
            anim.SetBool("IsJump", true);
            anim.SetTrigger("DoJump");
            IsJump = true;
        }
    }

}
