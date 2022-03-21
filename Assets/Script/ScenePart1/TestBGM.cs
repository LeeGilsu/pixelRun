using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class TestBGM : MonoBehaviour
{
    [SerializeField] AudioManager BGM_aidio;
    [SerializeField] Sprite[] BGM_VolumeButton;
    [SerializeField] Image BGM_ButtonImage;
    [SerializeField] SysTemManager Sys_Manager;
    public int BGM_Index;
    // Start is called before the first frame update
    private void Awake()
    {
     //   BGM_aidio = AudioManager.instance;
        BGM_aidio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    void Start()
    {
        BGM_ButtonImage = this.GetComponentInChildren<Image>();
        BGM_aidio.PlayBGM("BGM01");
        SceneStart();
      /*  if (BGM_aidio == null)
        {
            BGM_aidio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }*/

        //  mouseEvemt.m_MouseClickEvent += OnClick;

    }

    /*void OnClick(PointerEventData eventData) // 터치
    {
        if (BGM_Index == 0)
        {
            audiomanager.StopBGM();
            PlayerPrefs.SetInt("BGMImageValue", 1); // BGM on = 0번 스프라이트 / off는 1번 스프라이트에 맞게 playerprefs값을 조정하여 저장.
            BGM_ButtonImage.sprite = BGM_VolumeButton[1];
        }
        else
        {
            audiomanager.PlayBGM("BGM01");
            PlayerPrefs.SetInt("BGMImageValue", 0);
            BGM_ButtonImage.sprite = BGM_VolumeButton[0];
        }
    }*/
    // Update is called once per frame

    public void Click_Button()
    {
        if (BGM_Index == 0)
        {
            BGM_aidio.StopBGM();
            BGM_Index += 1;
            PlayerPrefs.SetInt("BGMImageValue", BGM_Index); // BGM on = 0번 스프라이트 / off는 1번 스프라이트에 맞게 playerprefs값을 조정하여 저장.
            BGM_ButtonImage.sprite = BGM_VolumeButton[BGM_Index];
        }
        else
        {
            BGM_aidio.PlayBGM("BGM01");
            BGM_Index -= 1;
            PlayerPrefs.SetInt("BGMImageValue", BGM_Index);
            BGM_ButtonImage.sprite = BGM_VolumeButton[BGM_Index];
        }

    }
    void SceneStart()
    {
        if (PlayerPrefs.HasKey("BGMImageValue"))
        {
            BGM_Index = PlayerPrefs.GetInt("BGMImageValue");
            switch (BGM_Index)
            {
                case 0:
                    BGM_ButtonImage.sprite = BGM_VolumeButton[0];
                    break;
                case 1:
                    BGM_aidio.StopBGM();
                    BGM_ButtonImage.sprite = BGM_VolumeButton[1];
                    break;
                default:
                    break;
                    
            }

        }
        else
        {
            BGM_Index = 0;
            PlayerPrefs.SetInt("BGMImageValue", 0);
            BGM_ButtonImage.sprite = BGM_VolumeButton[0];
        }
    }
}
