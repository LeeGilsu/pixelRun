﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerG : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI_Panel;
    public GameObject UI_FinishPanel;
    public Player player;

    private Scene scene;
    public float playtime;
    public TMPro.TMP_Text text;
    public TMPro.TMP_Text Ftext; // 종료 후 경과 시간 출력 텍스트.
    public bool m_stop = false;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(SystemPause());

        UI_Panel = GameObject.Find("GameOver");
        UI_FinishPanel = GameObject.Find("FinishStage");
        UI_Panel.SetActive(false);
        UI_FinishPanel.SetActive(false);
        Ftext = UI_FinishPanel.GetComponentInChildren<TMPro.TMP_Text>();

        scene = SceneManager.GetActiveScene();
        text = GetComponentInChildren<TMPro.TMP_Text>();
   
        playtime = 50f;

        DeleyTime(); 
    }

    // Update is called once per frame
    void Update()
    {
         if (m_stop != true)
          {
              playtime -= Time.deltaTime;
              text.text = "TIME : " + (int)playtime;
              if (playtime <= 0)
              {
                player.p_Point = 1;
                UI_Panel.SetActive(true);
                m_stop = true;
                DeleyTime();
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
                DeleyTime();
                isDone = false;
            }
            yield return null;
        }
        DeleyTime();
    }

    void DeleyTime()
    {
        if (m_stop)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(scene.name);
        player.p_Point = 0;
        m_stop = false;
        DeleyTime();
    }

    public void FinishST()
    {
        UI_FinishPanel.SetActive(true);
        m_stop = true; // 업데이트 타이머 정지.
        StartCoroutine(deley(1.5f));
        DeleyTime(); // 게임 정지.
        Ftext.text = "Clear Time :"+text.text;
        StopAllCoroutines();


    }

    IEnumerator deley(float del)
    {
        yield return new WaitForSeconds(del);
    }
}