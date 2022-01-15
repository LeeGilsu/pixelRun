using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearBox : MonoBehaviour
{
    public Transform clearbox;
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
}

