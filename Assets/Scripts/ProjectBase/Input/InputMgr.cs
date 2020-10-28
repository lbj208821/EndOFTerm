using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : BaseManager<InputMgr>
{
    private bool isStart = false;
    
    //构造方法中，添加update监听
    public InputMgr()
    {
        MonoMgr.GetInstance().AddUpdateListener(Myupdate);
    }
    //检测是否需要开启输入检测
    public void StartOrEndCheck(bool isOpen)
    {
        isStart = isOpen;
    }
    private void Myupdate()
    {
        if (!isStart)
            return;

    }
    private void CheckKeyCode(KeyCode key)
    {

    }
}
