using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBox : MonoBehaviour
{
    public Transform clearbox;
    private void OnEnable() 
    { 
        clearbox.localPosition = new Vector2(0, -Screen.height);
        clearbox.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDioalog()
    {
        clearbox.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
    }
}

