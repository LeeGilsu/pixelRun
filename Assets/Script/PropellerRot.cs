using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRot : MonoBehaviour
{
    float Timer;
    public float Rot_Speed;

    [SerializeField] GameObject player;
    // 플레이어 피격판정 
    public float force;

    public bool upLeft;
    public bool up;
    public bool upRight;
    public bool left;
    public bool right;
    public bool downLeft;
    public bool down;
    public bool downRight;
    // Start is called before the first frame update
    void Start()
    {
        Rot_Speed = 60f;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.smoothDeltaTime;
        RotatePropeller(new Vector3(0f, 0f, Rot_Speed * Timer));
    }

    private void RotatePropeller(Vector3 rot)
    {
        this.transform.rotation = Quaternion.Euler(rot);
        
    }
   /* public void Bounce(string vec)
    {
        if (vec == "upLeft")
        {
            GetComponent<Rigidbody>().AddForce(
                new Vector3(-0.7f, 0, 0.7f) * force, ForceMode.Impulse);

            Debug.Log("왼쪽 위로 튕긴다!");
        }
        if (up)
        {
            GetComponent<Rigidbody>().AddForce(
                new Vector3(0, 0, 1) * force, ForceMode.Impulse);

            Debug.Log("위로 튕긴다!");
        }
        if (upRight)
        {
            GetComponent<Rigidbody>().AddForce(
                new Vector3(0.7f, 0, 0.7f) * force, ForceMode.Impulse);

            Debug.Log("오른쪽 위로 튕긴다!");
        }
       if (left)
        {
            GetComponent<Rigidbody>().AddForce(
                Vector3.left * force, ForceMode.Impulse);

            Debug.Log("왼쪽으로 튕긴다!");
        }
        if (right)
        {
            GetComponent<Rigidbody>().AddForce(
                Vector3.right * force, ForceMode.Impulse);

            Debug.Log("오른쪽으로 튕긴다!");
        }
        if (downLeft)
        {
            GetComponent<Rigidbody>().AddForce(
                new Vector3(-0.7f, 0, -0.7f) * force, ForceMode.Impulse);

            Debug.Log("왼쪽 아래로 튕긴다!");
        }
        if (down)
        {
            GetComponent<Rigidbody>().AddForce(
                new Vector3(0, 0, -1) * force, ForceMode.Impulse);

            Debug.Log("아래로 튕긴다!");
        }
        if (downRight)
        {
            GetComponent<Rigidbody>().AddForce(
                new Vector3(0.7f, 0, -0.7f) * force, ForceMode.Impulse);

            Debug.Log("오른쪽 아래로 튕긴다!");
        }
    }*/


}
