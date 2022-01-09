using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryHummer : MonoBehaviour
{
    public GameObject Hummer1;
    // Start is called before the first frame update
    void Start()
    {
        Hummer1 = GameObject.Find("HummerR");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        Destroy(Hummer1);
     
    }
}
