using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel //找到所有控件，方便调用它
{
    // Start is called before the first frame update
    void Start()
    {
        GetControl<Button>("").onClick.AddListener(()=> 
        {
            UIManager.GetInstance().ShowPanel<BagPanel>("BagPanel");
        });//得到按钮,添加事件监听，点击按钮时显示背包面板
    }
    public override void ShowMe()
    {
        base.ShowMe();
        //更新玩家的信息
        GetControl<Text>("").text = GameDataManager.GetInstance().playerInfo.name;
        GetControl<Text>("").text= GameDataManager.GetInstance().playerInfo.lev.ToString();
        GetControl<Text>("").text = GameDataManager.GetInstance().playerInfo.money.ToString();
        GetControl<Text>("").text = GameDataManager.GetInstance().playerInfo.pow.ToString();
        GetControl<Text>("").text = GameDataManager.GetInstance().playerInfo.gem.ToString();
    }
}
