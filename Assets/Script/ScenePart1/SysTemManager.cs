using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SysTemManager : MonoBehaviour
{
    public static SysTemManager instance;

    // Start is called before the first frame update
    public GameObject System_message;
    public Transform tr;
    [SerializeField] AudioManager audio;
    [SerializeField] Scene scene;
    private void Awake()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        scene = SceneManager.GetActiveScene();
    }
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

        if (scene.buildIndex <= 0)
        {
            audio.PlayBGM("BGM01"); //씬 인덱스가 0이면 로비scene이므로 BGM01번 실행.
        }
        else if (scene.buildIndex == 1)
        {
            audio.PlayBGM("BGM02"); // Scene index =1 은 메인 신 맞는 비지엠 출력.
        }
        Debug.Log("현재씬 : " + scene.name + "씬 인덱스" + scene.buildIndex);

        SetResolution();
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

    private void SetResolution()
    {
        int SetWidth = 1920; //초기 Width값
        int SetHeight = 1080; //초기 Height값

        int DeviceWideh = Screen.width; //실행 디바이스의 Width값
        int DeviceHeight = Screen.height; //실행중인 디바이스의 Higth값

        Screen.SetResolution(SetWidth, (int)(((float)DeviceHeight / DeviceWideh) * SetWidth), true);
        if ((float)SetWidth / SetHeight < (float)DeviceWideh / DeviceHeight) //기존 설정해상도보다 실행 기기의 해상도가 더 큰경우.
        {
            float newWidth = ((float)SetWidth / SetHeight) / ((float)DeviceWideh / DeviceHeight); //새로운 너비 계산.
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0, newWidth, 1f); //새로운 Camera->Rect값 적용.
        }
        else // 기존 기기설정 해상도가 더 큰경우
        {
            float newHeight = ((float)DeviceWideh / DeviceHeight) / ((float)SetWidth / SetHeight); // 새로운 높이 계산

            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 계산된 newHeight를 적용.

        }
    }
}