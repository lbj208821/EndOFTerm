using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//在外部调用的示例

/// <summary>
/// 继承UIBasePanel
/// 这个Canvas下面的所有UI都可以被GetControl直接找到
/// </summary>
public class UITest : MonoBehaviour
{
    // Start is called before the first frame update
   private void Start()
    {
        //GetControl<Button>("").onClick.AddListener(() =>
        //{
        //    Debug.Log("开始游戏");
        //});
        //GetControl<Button>("").onClick.AddListener(() =>
        //{
        //    Debug.Log("设置");
        //});
        UIManager.GetInstance().ShowPanel<LoginPanel>("LoginPanel", E_UI_Layer.Top, ShowPanelOver);
       
    }
    private void ShowPanelOver(LoginPanel panel)
    {
        panel.InitInfo();
        Invoke("DelayHide", 6);
    }
    private void DelayHide()
    {
        UIManager.GetInstance().HidePanel("LoginPanel");
        Debug.Log("隐藏");
    }
}
