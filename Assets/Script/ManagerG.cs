using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerG : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI_Panel;
    public GameObject _clearbox;
    public Player player;
    public JoyStick joystick;

    private Scene scene;
    public float Max_Playtime;
    public float Currnt_playtime; // 현재 진행중인 시간
    public float Best_Playtime;   // 최고기록 시간.

    //[폰트]
    public TMPro.TMP_Text text;
    public TMPro.TMP_Text Ftext; // 종료 후 경과 시간 출력 텍스트.
    public TMPro.TMP_Text BestTimer; // 최고 기록 저장텍스트
    
    //[작동상태 확인]
    public bool m_stop = false;

    //클리어 박스 출력 시 점수 이미지 애니매이션 그룹
    [SerializeField] AudioManager audio;

    private void Awake()
    {
        //   _clearbox = GameObject.Find("ClearBox");//.GetComponent<Canvas>();
        //    _clearbox.SetActive(false);
        // PlayerPrefs.DeleteKey("BestTime"); 
        audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(SystemPause());

        UI_Panel = GameObject.Find("GameOver");
        UI_Panel.SetActive(false);
        Ftext = _clearbox.GetComponentInChildren<TMPro.TMP_Text>(); // GetComponentInChildren은 하위 객채 Text 첫번째 오브젝트를 불러옴.
        BestTimer = GameObject.Find("BestTime").GetComponent<TMP_Text>(); 

        scene = SceneManager.GetActiveScene();
        text = GetComponentInChildren<TMPro.TMP_Text>();
        Max_Playtime = 60f; // 초기 시간 지정
        Currnt_playtime = 0.000f;
        audio.PlayBGM("BGM02");

        DeleyTime(m_stop);

        BestClearTimeSet();
    }

    private void BestClearTimeSet()
    {
        Best_Playtime = PlayerPrefs.GetFloat("BestTime");

        BestTimer.text = "BEST : " + Best_Playtime.ToString("F2");

        if (Best_Playtime == 0)
        {
            BestTimer.text = "BEST : - - ";
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (m_stop == false && player.current_State == false)
          {
              Currnt_playtime += Time.deltaTime;
              text.text = "TIME : " + Currnt_playtime.ToString("F2");

            if (Currnt_playtime >= Max_Playtime) // 최대시간을 넘겼을 시 중단.
            {
                m_stop = true;
            }
     }

    }
    IEnumerator SystemPause()
    {
        bool isDone = true;

        while (isDone)
        {
            if (player.GetComponent<Player>().MaxHP == 0)
            {
                Debug.Log("Game Over");
                player.p_Point = 1;
                yield return new WaitForSeconds(2.0f);
                UI_Panel.SetActive(true);
                m_stop = true;
                DeleyTime(false);
                isDone = false;
            }
            yield return null;
        }
        DeleyTime(m_stop);
    }

    void DeleyTime(bool v)
    {
        switch (v)
        {
            case false: //딜레이 없을시 정상구동
                Time.timeScale = 1.0f;
                break;
            case true: // 딜레이가true면 정지
                Time.timeScale = 0f; //정지->0 정상적인 시간흐름 -> 1
                break;
        }
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(scene.name);
        player.p_Point = 0;
        m_stop = false;
       
        DeleyTime(m_stop);
    }

    public void FinishST()
    {
        SaveTimer();
        player.current_State = true; // 스테이지 클리어 후 클레이어 이동 및 시간 정지.

        _clearbox.SetActive(true); //클리어 오브잭트 활성화.
        Ftext.text = "Clrar "+text.text; // 클리어 시간 표시.남은시간(최대시간 - 진행시간)
        scorecalculate(); // 남은 시간에따른 _clearbox의 UI활성화.

        StopAllCoroutines();
    }

    private void SaveTimer()
    {
        if (Currnt_playtime < Best_Playtime || Best_Playtime == 0)
        {
            BestTimer.text = "BEST : " + Currnt_playtime.ToString("F2"); // 베스트 타임 텍스트를 바뀐 최고기록으로 교체.

            PlayerPrefs.SetFloat("BestTime", Currnt_playtime); //현재 클리어타임이 기존 Best_Playtime보다 빠르거나 기존 데이터가없으면 현재 클리어시간 저장.
        }
    }

    void scorecalculate()
    {
        if      (Currnt_playtime <= 20) { _clearbox.GetComponent<ClearBox>().scoreImage(3); } //20초 안에 클리어 시 <별 3개>
        else if (Currnt_playtime <= 30) { _clearbox.GetComponent<ClearBox>().scoreImage(2); } //30초 안에 클리어 시 <별 2개>
        else                            { _clearbox.GetComponent<ClearBox>().scoreImage(1); } //그외 클리어 타임 기록 시 <별 1개>.

    }
}
