using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRot : MonoBehaviour
{
 
    [SerializeField]
    private float RotSpeed = 10.0f;
    [SerializeField]
    private float x = 0.0f;
    // Start is called before the first frame update

    Transform target;

    private float curY = 0;
    private float temp = 0;
    float sd;
    bool Isdone;
    public GameObject round_1;
    public bool MenuState;

   // public GameObject Sys_Box;
    void Start()
    {
        MenuState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightRot();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftRot();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadingSceneController.LoadScene("MainStage");
        }

        if(MenuState == true) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Debug.Log(hit.collider.tag);
                    if (hit.collider.tag == "Round")
                    {
                        Debug.Log("1라운드가 클릭됨.");
                        AudioManager.instance.StopBGM();
                        LoadingSceneController.LoadScene("MainStage");
                    }
                }
            }
        }
        // 메시지박스가 출력 시 RaycastHit를 작동 중지시킴.
        if (GameObject.Find("SystemMessage(Clone)") != null || GameObject.Find("setting_ButtonGroup") != null) { MenuState = false; } 
        else if(GameObject.Find("SystemMessage(Clone)") == null && GameObject.Find("setting_ButtonGroup") == null) { MenuState = true; }
        
    }

    public void LeftRot()
    {
        AudioManager.instance.PlaySFX("Tuch");
        StartCoroutine(moveRot(0));
        Debug.Log("left");
    }

    public void RightRot()
    {
        AudioManager.instance.PlaySFX("Tuch");
        StartCoroutine(moveRot(1));
    }

    public void SceneTestbutton()
    {
        LoadingSceneController.LoadScene("MainStage");
    }

    IEnumerator moveRot(float i)
    {
        if (i == 0)
        {
            while (!Isdone)
            {
                x += Time.deltaTime * 45;
                curY -= x;
                transform.rotation = Quaternion.Euler(0, curY, 0);
                if (curY <= temp - 90f)
                {
                    temp -= 90.0f;
                    x = 0;
                    transform.rotation = Quaternion.Euler(0, temp, 0); // 정확한 90도 회전을위해 다시한반 위치 설성.
                    yield break;
                }

                yield return null;
            }
        }
        /////
        while (!Isdone)
        {
            x += Time.deltaTime * 45;
            curY += x;
          
            transform.rotation = Quaternion.Euler(0, curY, 0);
            if (curY >= temp + 90f)
            {
                temp += 90.0f;
                x = 0;
                transform.rotation = Quaternion.Euler(0, temp, 0);
                Debug.Log(curY);
                Debug.Log(temp);
                yield break;        
            }

            yield return null;
        }
    }

}
