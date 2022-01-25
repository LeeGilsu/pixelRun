using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CubeDrop : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigi;
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           Invoke("DropCube", 1.2f);
        }
        if (collision.gameObject.tag == "EndGround")
        {
            Destroy(gameObject, 1f);
        }
    }

    void DropCube()
    {
        rigi.isKinematic = false;
    }

}
