using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public void Puase_on()
    {
        Time.timeScale = 0; // OPen MessageBox 애니매이 종료 이후 시스템 pause 활성화 = 0;
      //  OnApplicationPause(ture);
    }
}
