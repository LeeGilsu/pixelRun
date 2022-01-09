using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RHummer : MonoBehaviour
{
    public GameObject burst;
    public Transform boomPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void RboomBurst()
    {
        Instantiate(burst, boomPos.transform.position, Quaternion.identity);
    }
}
