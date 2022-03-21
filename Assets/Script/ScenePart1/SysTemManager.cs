using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SysTemManager : MonoBehaviour
{
    public static SysTemManager instance;

    // Start is called before the first frame update
    public GameObject System_message;
    public Transform tr;
    private void Start()
    {
        var obj = FindObjectsOfType<SysTemManager>();

        if (obj.Length == 1)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        tr = this.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Input_ESC();
        }
    }

    void Input_ESC()
    {
        if (GameObject.Find("SystemMessage(Clone)") == null)
            Instantiate(System_message, new Vector3(tr.position.x, tr.position.y, tr.position.z), Quaternion.Euler(0, 0, 0));
    }
}