using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MisailMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firOb;
    public Vector3 effpos;
    public Vector3 CubeTr;
    AudioManager au;

    void Start()
    {
       this.transform.rotation = Quaternion.Euler(0,0,-90f);
        CubeTr = GetComponent<Transform>().position;
        au = AudioManager.instance;
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        effpos = GameObject.Find("EffPos").transform.position;
        transform.Translate(2f*Time.deltaTime*20f,0,0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            au.PlaySFX("Bomb");
            Instantiate(firOb, effpos, Quaternion.identity);
        }
    }

}
