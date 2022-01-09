using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisailDrop : MonoBehaviour
{
    Rigidbody rigi;
    public GameObject misail; // 프리팹 오브택드 끌어다 사용
    Vector3 GroundTR;
    public MisailMove mi_move;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        GroundTR = GetComponent<Transform>().position;
        GroundTR.y += 20f;
        mi_move = misail.GetComponent<MisailMove>();
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                Instantiate(misail, GroundTR, Quaternion.Euler(0, 0, 0));
        }
        if (collision.gameObject.tag == "Misail")
        {
            Destroy(gameObject);
        }
    }

    void DropCube()
    {

    }

}
