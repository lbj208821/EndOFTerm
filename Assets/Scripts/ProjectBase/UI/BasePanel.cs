using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// UI管理模块
/// UI基类
/// </summary>
//使用方法，在UI的canvas上挂载一个继承自BasePanel的脚本，这个Canvas下面的所有UI都可以被Getcontrol找到

public class BasePanel : MonoBehaviour
{
    //通过里式转换原则，来存储所有的ui控件
    private Dictionary<string, List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();

    private void Awake()
    {
        FindChildControl<Button>();
        FindChildControl<Image>();
        FindChildControl<Text>();
        FindChildControl<Toggle>();
        FindChildControl<ScrollRect>();
        FindChildControl<Slider>();


    }
    //得到对应名字的对应控件脚本
    protected T GetControl<T>(string controlName)where T : UIBehaviour
    {
        if(controlDic.ContainsKey(controlName))
        {
            for(int i = 0;i<controlDic[controlName].Count;i++)
            {
                //对应字典的值（集合），符合要求的类型的就返回出去
                if(controlDic[controlName][i] is T)
                {
                    return controlDic[controlName][i] as T;
                }
            }
        }
        return null;
    }
    //找到相对应的UI控件并记录到字典中
    private void FindChildControl<T>()where T : UIBehaviour
    {
        T[] controls = this.GetComponentsInChildren<T>();
        string objname;
        for(int i = 0;i<controls.Length;i++)
        {
            objname = controls[i].gameObject.name;
            if(controlDic.ContainsKey(objname))
            {
                controlDic[objname].Add(controls[i]);
            }
            else
            {
                controlDic.Add(objname, new List<UIBehaviour>() { controls[i] });//如果找不到名字，就新建一个
            }
        }
    }

    //让子类重写（覆盖）此方法，来实现UI的隐藏与出现
    public virtual void ShowMe()
    {

    }
    public virtual void HideMe()
    {

    }
}
