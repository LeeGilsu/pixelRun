using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearBox : MonoBehaviour
{
    public Transform clearbox;

    // 클리어 시 이미지 애니매이션 그룹
    public GameObject StarImageGroup;
    public GameObject star_01;
    public GameObject star_02;
    public GameObject star_03;

    private void Start()
    {

    }
    private void OnEnable() 
    { 
        clearbox.localPosition = new Vector2(0, -Screen.height);
        clearbox.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDioalog() //메시지 박스 LeanTween을 이용한 하단으로 내려주는 함수.( 현재 사용안함 )
    {
        clearbox.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
    }

    public void OK_Button()
    {
        LoadingSceneController.LoadScene("StartScene"); // OK버튼 클릭 시 로딩 화면 전환 후 시작 화면으로 전환.
    }

    public void scoreImage(int score) //점수에 맞는 스코어를 입력받아 이미지 애니매이션 작동을위한 switch문
    {

        switch (score)
        {
            case 1:
                star_01.SetActive(true);
                break;
            case 2:
                star_01.SetActive(true);
                star_02.SetActive(true);
                break;
            case 3:
                star_01.SetActive(true);
                star_02.SetActive(true);
                star_03.SetActive(true);
                break;
        }
    }

}

