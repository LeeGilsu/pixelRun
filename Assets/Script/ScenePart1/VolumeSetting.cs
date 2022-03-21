using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public Slider Slider_BGM;
    public Slider Slider_SFX;
    public GameObject Setting_Group;
    private SphereRot sp;
    public AudioManager audioManager;
    // Start is called before the first frame update
    private void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Setting_Group = GameObject.Find("setting_ButtonGroup"); Setting_Group.SetActive(false); // 시작 시 안보이기.
        sp = GameObject.Find("Sphere").GetComponent<SphereRot>();
        if (PlayerPrefs.HasKey("BGM"))
        {
            Slider_BGM.value = PlayerPrefs.GetFloat("BGM");
        }
        else
        {
            Slider_BGM.value = 1f;
            BGM_Volume(1f);
        }
        if (PlayerPrefs.HasKey("SFX"))
        {
            Slider_SFX.value = PlayerPrefs.GetFloat("SFX");
        }
        else
            {
            Slider_SFX.value = 1f;
            SFX_volume(1f);
        } 
        //Slider_BGM.value = 1f;
        //Slider_SFX.value = 1f;  // 슬라이더 초기값 1로 지정.

    }

    void Start()
    {
    }

    public void BGM_Volume(float b_Volume)
    {
        audioManager.BGM_VolumeCtr(b_Volume);
    }

    public void SFX_volume(float s_Volume)
    {
        audioManager.SFX_VolumeCtr(s_Volume);
    }
    public void quitCkilck()
    {
        sp.MenuState = true; //버튼 raycast 활성화.
        CloseBackgroundAnim();
    }
    public void CloseBackgroundAnim()
    {
        Setting_Group.SetActive(false); // 세팅 내부 이미지들 가리기
        this.GetComponent<Animator>().SetTrigger("Setting_Close");
    }

    public void OpenBackgroundAnim()
    {
        this.GetComponent<Animator>().SetTrigger("Setting_Open");
    }
    public void OpenSettingUI() //오픈 애니메이션 끝날 시 클립 이벤트를 통하여 호출.
    {
        Setting_Group.SetActive(true); //내부 이미지들 출력
    }
}
