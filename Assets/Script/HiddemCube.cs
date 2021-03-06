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

        if(dis.magnitude <= 3)
        {
            Cuanim.SetTrigger("IsHidden");
            
        }
        else { }
    }

    public void Destroy_Cube()
    {
        Destroy(gameObject);
    }
}
