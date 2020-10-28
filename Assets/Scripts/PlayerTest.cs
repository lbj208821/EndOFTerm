using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTest : MonoBehaviour
{
    private void Start()
    { 
        UnityAction<object> LeftAction = null;
        LeftAction += leftDown;
        LeftAction += leftDown2;
        UnityAction<object> RightAction = null;

        RightAction += RightDown;
        RightAction += RightDown2;
        EventCenter.GetInstance().AddEventListener("LeftMouse", LeftAction);
        EventCenter.GetInstance().AddEventListener("RightMouse", RightAction);

    }

    private void leftDown(object info)
    {
        Debug.Log("左键按下");
        //将Object的类型转换成test类，从而调用test属性name
        Debug.Log("test的对象的name是：" + (info as testEvent).name);
    }

    private void leftDown2(object info)
    {
        Debug.Log("白天了");
    }

    private void RightDown(object info)
    {
        Debug.Log("右键按下");
        Debug.Log("test的对象的name是：" + (info as testEvent).name);
    }

    private void RightDown2(object info)
    { 
        Debug.Log("晚上了");
    }
}
