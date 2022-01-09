using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddemCube : MonoBehaviour
{
    public Transform playerTr;
    public Transform MyTr;
    Animator Cuanim;
    // Start is called before the first frame update
    void Start()
    {
        MyTr = GetComponent<Transform>();
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        Cuanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dis = playerTr.position - this.transform.position;

        if(dis.magnitude <= 5)
        {
            Cuanim.SetTrigger("IsHidden");
            Destroy(gameObject,0.35f);
        }
        else { }
    }
}
