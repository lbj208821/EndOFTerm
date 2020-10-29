using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPanel : BasePanel//找到所有控件，方便调用它
{
    // Start is called before the first frame update
    void Start()
    {
        GetControl<Button>("").onClick.AddListener(() =>
        {
            UIManager.GetInstance().HidePanel("BagPanel");
        });//点击关闭按钮隐藏面板
    }

   
}
