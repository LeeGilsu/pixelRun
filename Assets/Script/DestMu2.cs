using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestMu2 : MonoBehaviour
{
    public GameObject Hummer;
    // Start is called before the first frame update
    void Start()
    {
        Hummer = GameObject.Find("Hummer");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(Hummer);

    }
}
