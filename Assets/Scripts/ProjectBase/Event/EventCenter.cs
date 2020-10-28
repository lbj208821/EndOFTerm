using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//事件监听
public class EventCenter : BaseManager<EventCenter>
{   //字典中key对应着事件的名字
    //value对应的是监听这个事件对应的委托方法们（重点圈住：们）
    private Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string, UnityAction<object>>();
    // Start is called before the first frame update
   
    //添加事件监听
    //第一个参数：实践的名字
    public void AddEventListener(string name,UnityAction<object> action)//考虑到会传入不同的值，给委托添加泛型，传入不同参数
    {
        //有没有对应的事件监听
        //有的情况
        if(eventDic.ContainsKey(name))
        {
            eventDic[name] += action;
        }
        //没有的情况
        else
        {
            eventDic.Add(name, action);
        }

    }
    //通过事件名字进行事件触发
    public void EventTrigger(string name,object info)
    { //有没有对应的事件监听
        //有的情况（有人关心这个事件）
        if(eventDic.ContainsKey(name))
        {
            //调用委托（依次执行委托中的方法）
            eventDic[name](info);
        }

    }
    public void RemoveEventListener(string name, UnityAction<object> action)
    {
        if (eventDic.ContainsKey(name))
        {
            //移除这个委托
            eventDic[name] -= action;
        }
    }
    //清空所有事件监听（主要用于切换场景时）
    public void Clear()
    {
        eventDic.Clear();
    }
}
