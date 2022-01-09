using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hummer : MonoBehaviour
{
    public  GameObject burst;
    public Transform boomPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void boomBurst()
    {
        Instantiate(burst, boomPos.transform.position, Quaternion.identity);
   
    }
}
