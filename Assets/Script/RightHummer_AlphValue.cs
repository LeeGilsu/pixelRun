using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHummer_AlphValue : MonoBehaviour
{
    MeshRenderer R_Mesh;
    public float i = 1;
    // Start is called before the first frame update
    void Start()
    {
        R_Mesh = GameObject.Find("Hammer_R").GetComponentInChildren<MeshRenderer>();
        R_Mesh.sharedMaterial.color = new Color(R_Mesh.sharedMaterial.color.r, R_Mesh.sharedMaterial.color.g, R_Mesh.sharedMaterial.color.b, 1); // 시작시 알파값 초기화
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            i = 1f;
            R_Mesh.sharedMaterial.color = new Color(R_Mesh.sharedMaterial.color.r, R_Mesh.sharedMaterial.color.g, R_Mesh.sharedMaterial.color.b, i / 10);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            i = 10f;
            R_Mesh.sharedMaterial.color = new Color(R_Mesh.sharedMaterial.color.r, R_Mesh.sharedMaterial.color.g, R_Mesh.sharedMaterial.color.b, i / 10);
        }
    }
}
