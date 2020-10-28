using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class testEvent : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //触发事件
            EventCenter.GetInstance().EventTrigger("LeftMouse",this);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            //触发事件
            EventCenter.GetInstance().EventTrigger("RightMouse",this);
        }
    }
    
}
