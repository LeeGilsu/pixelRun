using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinshItem : MonoBehaviour
{
    public Transform Item;
    public GameObject Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameManager");
        Item = this.GetComponent<Transform>();
        //this.transform.LeanMoveLocalY(0, 1).setEaseOutQuart().setLoopPingPong();
        this.transform.LeanMoveLocalY (17f,1).setEaseOutQuart().setLoopPingPong();
        //  (현재 위치에서 다음 튕겨서 올라갈위치의 y값 / 가는 시간 int) / setEaseOutQuart = 애니매이션 효과중 부드럽게 움직일수있도록 해주는 함수 
    }

    // Update is called once per frame
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        CoinRotate(new Vector3(0f, (Mathf.Cos(timer) * 0.5f + 0.5f) * 360f, 0f));
        // Y축을 기준으로 코싸인 그래프를 따라서 0도에서360도 사이의 각도로 회전.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Manager.GetComponent<ManagerG>().FinishST();
            //코인과 플레이어 콜라이더가 닿을 시 게임 매니저 호출하여 FinishST 함수 호출 
        }
    }

    public void CoinRotate(Vector3 rotation)
    {
        this.transform.rotation = Quaternion.Euler(rotation);
    }

}
