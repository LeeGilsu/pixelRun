using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");

    }

    private void LateUpdate() // 모든 업데이트의 프레임 마지막에 한프레임씩 작동 Late
    {
        Vector3 newPosition = Player.transform.position;
        newPosition.y = this.transform.position.y;
        transform.position = newPosition;
    }
}
