using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 公共mono模块
/// </summary>

//有的类没有继承monobehaviour，但是又希望用到mono的东西，于是需要公共mono模块
public class MonoController : MonoBehaviour
{
    private event UnityAction updateEvent;
    // Start is called before the first frame update
   private void Start()
    {
        //此对象不可以移除
        //从而方便别的对象找到物体，从而获取脚本，添加方法
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
       if(updateEvent!=null)
        {
            updateEvent();
        }
    }

    //为外部提供的添加帧更新事件的方法
    public void AddUpdateListener(UnityAction func)
    {
        updateEvent += func;
    }
    //为外部移除帧更新事件的方法
    public void RemoveUpdateListener(UnityAction func)
    {
        updateEvent -= func;
    }
}
