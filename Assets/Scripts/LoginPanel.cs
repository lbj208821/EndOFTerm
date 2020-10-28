using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    // Start is called before the first frame update
    private void Start()
    {
        GetControl<Button>("Button").onClick.AddListener(() =>
        {
            Debug.Log("我是顶层");
        });
    }
    public void InitInfo()
    {
        Debug.Log("初始化了数据");
    }
    
}
