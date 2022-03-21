using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Hammer : MonoBehaviour
{
    public GameObject burst;
    public Transform boomPos;
    public AudioSource audio;
   // MeshRenderer mesh;
    float i = 10;
    public float f = 1;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
     //   mesh = GetComponentInChildren<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
     //   mesh.sharedMaterial.color = new Color(mesh.sharedMaterial.color.r, mesh.sharedMaterial.color.g, mesh.sharedMaterial.color.b, f / i);
    }

    void RboomBurst()
    {
        audio.Play();
        Instantiate(burst, boomPos.transform.position, Quaternion.identity);
    }

  
}
