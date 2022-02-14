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
    void Start()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 1000);

            if (hit.collider == round_1)
            {
                Debug.Log("터치");
            }
        }
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
