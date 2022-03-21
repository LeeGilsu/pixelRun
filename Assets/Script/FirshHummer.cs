using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirshHummer : MonoBehaviour
{
    public Animator Hanim;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Hanim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void HummAnimStart()
    {
        Hanim.SetTrigger("HAtt");

    }
    public void TimeSpeed()
    {
        Time.timeScale = 1; // 느려짐 효과 되돌리기
    }

}
