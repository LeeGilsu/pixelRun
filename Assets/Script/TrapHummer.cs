using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHummer : MonoBehaviour
{
    public FirshHummer F_H;
    public static int AttackCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        F_H = GameObject.Find("FinshHummer").GetComponent<FirshHummer>();
        AttackCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (AttackCount == 0)
            {
                AttackCount++;
                F_H.HummAnimStart();
                Time.timeScale = 0.5f;
            }
        }
    }

}
