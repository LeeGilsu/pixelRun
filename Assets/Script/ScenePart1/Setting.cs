using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Setting : MonoBehaviour
{
    public MouseEvent m_mouse = null; // 마우스 이벤트 인터페이스 
    
    [SerializeField]
    private SphereRot sp;
    private VolumeSetting vs;
    void Start()
    {
        sp = GameObject.Find("Sphere").GetComponent<SphereRot>();
        vs = GameObject.Find("SettingBackGround").GetComponent<VolumeSetting>();

        m_mouse.m_MouseClickEvent += OnClick;
        m_mouse.m_MouseExitEvent += MouseOut;
    }

    void OnClick(PointerEventData eventData) // 터치
    {
        StartCoroutine(SizeChange(1.2f, 10f));
    //    sp.MenuState = false; //버튼 raycast 정지.
        vs.OpenBackgroundAnim(); // Setting IU 애니매이션 출력.
    }
    void MouseOut(PointerEventData eventData) // 터치 아웃
    {
        StartCoroutine(SizeChange(1, 10f));
    }

    IEnumerator SizeChange(float target, float speed)
    {
        Vector2 scale = GetComponent<RectTransform>().localScale; //현재 컴포넌트의 RectTr의 Scale를 가져온다.
        while (Mathf.Abs(scale.x - target) > 0.1f)
        {
            scale = Vector2.Lerp(scale, new Vector2(target, target), Time.smoothDeltaTime * speed);
            GetComponent<RectTransform>().localScale = scale;
            yield return null;
        }
        GetComponent<RectTransform>().localScale = new Vector2(target, target);
    }

}
