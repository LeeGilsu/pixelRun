using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMessageBox : MonoBehaviour
{
    SysTemManager sys;
    public RectTransform Message_Group;
    public Animator Box_Anim;
    // Start is called before the first frame update
    void Start()
    {
        sys = GameObject.Find("SystemManager").GetComponent<SysTemManager>();
        Message_Group.anchoredPosition = new Vector2(0, -1500f); // 초기 생성 시 화면 하단에 생성.
        //RectTransform값을 지정하기위해선 anchoredPosition을 사용해야 한다.

        Box_Anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EXIT_Click()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 유니티 에디터에서 플레이 종료
#else
        Application.Quit(); // 어플리케이션 종료
#endif

        /*#if UNITY_ANDROID // 안드로이드만 종료 처리를 하기 위해 if사용.
                Application.Quit();
        #endif*/
    }

    public void Resume_Click()
    {
        Time.timeScale = 1; //Restart버튼 클릭 시 시스템 활성 화 후 게임 시작.
        Box_Anim.SetTrigger("Close"); // colse 애니매이션을 실행해준다.
        Destroy(this.gameObject, 1f); // 1초 후 게임 오브잭트를 삭제.
    }

}
