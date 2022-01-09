using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirshHummer : MonoBehaviour
{
    public Animator Hanim;
    // Start is called before the first frame update
    void Start()
    {
        Hanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void HummAnimStart()
    {
        Hanim.SetTrigger("HAtt");

    }


}
