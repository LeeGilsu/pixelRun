using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHammer_AlphValue : MonoBehaviour
{
    MeshRenderer L_Mesh;
    public float i = 1;
    // Start is called before the first frame update
    void Start()
    {
        L_Mesh = GameObject.Find("Hammer_L").GetComponentInChildren<MeshRenderer>();
        L_Mesh.sharedMaterial.color = new Color(L_Mesh.sharedMaterial.color.r, L_Mesh.sharedMaterial.color.g, L_Mesh.sharedMaterial.color.b, 1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            i = 1f;
            L_Mesh.sharedMaterial.color = new Color(L_Mesh.sharedMaterial.color.r, L_Mesh.sharedMaterial.color.g, L_Mesh.sharedMaterial.color.b, i / 10);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            L_Mesh.sharedMaterial.color = new Color(L_Mesh.sharedMaterial.color.r, L_Mesh.sharedMaterial.color.g, L_Mesh.sharedMaterial.color.b, 1);
        }
    }
}
