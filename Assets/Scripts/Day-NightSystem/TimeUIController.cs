using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUIController : MonoBehaviour
{
    private int tempTime = 0;
    void FixedUpdate()
    {
        RotateClock();
    }
    
    private void RotateClock()
    {
        if (TimeController.Instance.GetCurrentHour() > tempTime)
        {
            tempTime = TimeController.Instance.GetCurrentHour();
            transform.Rotate(0,0, -30f);
        }
    }
}
