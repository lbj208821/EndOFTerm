using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.AI;


//抽屉数据，池子中的一列容器
public class PoolData
{
    //抽屉中，对象挂载的父节点
    public GameObject fatherObj;

    //对象的容器
    public List<GameObject> poolList;

    public PoolData(GameObject obj,GameObject poolObj)
    {
        //根据obj创建一个同名父类空物体，它的父物体为总Pool空物体
        fatherObj = new GameObject(obj.name);
        fatherObj.transform.parent = poolObj.transform;

        poolList = new List<GameObject>() { };

        PushObj(obj);
    }
    public void PushObj(GameObject obj)
    {
        //存起来
        poolList.Add(obj);
        //设置父对象
        obj.transform.parent = fatherObj.transform;
        //失活，让其隐藏
        obj.SetActive(false);

    }
    public GameObject GetObj()
    {
        GameObject obj = null;
        //取出第一个
        obj = poolList[0];
        poolList.RemoveAt(0);

        //激活，让其展示
        obj.SetActive(true);

        //断开父子关系
        obj.transform.parent = null;

        return obj;
    }

}
/// <summary>
/// 缓存池模块
/// </summary>
public class PoolMgr : BaseManager<PoolMgr>
{
    //缓存池容器(衣柜)
    public Dictionary<string, PoolData> poolDic = new Dictionary<string, PoolData>();

    private GameObject poolObj;
    //往外拿东西
    public void GetObj(string name,UnityAction<GameObject> callback)
    {
        if(poolDic.ContainsKey(name)&&poolDic[name].poolList.Count>0)//有dictionary，dic中有东西,第二个参数代表后面的gameobject
        {
            //通过委托返回给外部，让外部进行使用
            callback(poolDic[name].GetObj());
            //obj = poolDic[name].GetObj();
            //poolDic[name].RemoveAt(0);//把第一个移除掉,拿出去
        }
        else
        {
            //缓存池中没有该物体，我们去目录中加载
            //外面传一个预设体的路径和名字，内部加载它
            ResMgr.GetInstance().LoadAsync<GameObject>(name, (o) =>
             {
                 o.name = name;
                 callback(o);
             }
            );
            //obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            //obj.name = name;//把对象名字改成和池子名字一样,push的时候不用一个一个push
        }
        //激活
        //obj.SetActive(true);
        //断开缓存池物体与poolobj的父子关系
        //obj.transform.parent = null;
       // return obj;
    }

    //还暂时不用的东西给我
    public void PushObj(string name,GameObject obj)
    { 
        if (poolObj==null)
        {
            poolObj = new GameObject("Pool");
        }
        obj.transform.parent = poolObj.transform;
        //失活
        obj.SetActive(false);
        //里面有抽屉
        if (poolDic.ContainsKey(name))
        {
            //poolDic[name].Add(obj);
            poolDic[name].PushObj(obj);
        }
        //里面没有抽屉
        else
        {
            //创建一个抽屉
            // poolDic.Add(name, new List<GameObject>() { obj });
            poolDic.Add(name, new PoolData(obj, poolObj) { });
         }
      
    }

    //清空缓存池
    //在切换场景时使用
    public void Clear()
    {
        poolDic.Clear();
        poolObj = null;
    }
}
