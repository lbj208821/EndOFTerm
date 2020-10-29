using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.GetInstance().Init();

        
        Debug.Log(GameDataManager.GetInstance().GetItemInfo(1).name);

        //显示主面板
        UIManager.GetInstance().ShowPanel<MainPanel>("MainPanel", E_UI_Layer.Bot);//放在哪一层
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
