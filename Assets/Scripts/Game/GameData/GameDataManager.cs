using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameDataManager : BaseManager<GameDataManager>
{
    //玩家信息存储路径
    private static string PlayerInfo_Url = Application.persistentDataPath+"/PlayerInfo.txt";//一个可读可写的路径
    
    /// <summary>
    /// 玩家数据 一开始为空
    /// </summary>
    public Player playerInfo;

    private Dictionary<int, Item> itemInfos = new Dictionary<int, Item>();//建一个字典 把list的内容移到字典中
    /// <summary>
    /// 初始化数据
    /// </summary>
   public void Init()
    {
        //加载Resources文件夹下的json 获取它的内容
        string info = ResMgr.GetInstance().Load<TextAsset>("Json/ItemInfo").text;//同步加载
        Debug.Log(info);
        //根据json文件内容 解析成对赢得数据结构 并存储起来
        Items items = JsonUtility.FromJson<Items>(info);
        Debug.Log(items.info.Count);

        for(int i=0;i<items.info.Count;++i)
        {
            itemInfos.Add(items.info[i].id, items.info[i]);//把list中的内容放入到字典中
        }

        //初始化 角色信息
        if(File.Exists(PlayerInfo_Url))
        {
            //取这个文件的信息
            byte[] bytes=File.ReadAllBytes(PlayerInfo_Url);//保存字节数组
            //字节数组转成string
            string json = Encoding.UTF8.GetString(bytes);
            //把字符串转换成玩家数据结构
            playerInfo = JsonUtility.FromJson<Player>(json);

            Debug.Log(playerInfo.name);
        }
        else
        {
            //没有玩家数据时 初始化一个默认数据
            playerInfo = new Player();
            SavePlayerInfo();
        }
    }

    /// <summary>
    /// 保存玩家信息
    /// </summary>
    public void SavePlayerInfo()
    { 
        //并且存储它
        string json = JsonUtility.ToJson(playerInfo);
        //保存,把字节数组存到路径
        File.WriteAllBytes(PlayerInfo_Url, Encoding.UTF8.GetBytes(json));
    }

    /// <summary>
    /// 根据道具ID 得到道具的详细信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Item GetItemInfo(int id)
    {
        if (itemInfos.ContainsKey(id))//如果有这个id就可以直接返回，用来获取信息的，不用来修改
            return itemInfos[id];
        return null;
    }
}

/// <summary>
/// 玩家基础信息
/// </summary>
public class Player
{
    public string name;
    public int lev;
    public int money;
    public int gem;
    public int pow;
    public List<ItemInfo> items;//道具
    public List<ItemInfo> equips;//装备
    public List<ItemInfo> gems;//宝石

    //构造函数
    public Player()
    {
        name = "josh";
        lev = 1;
        money = 9999;
        gem = 0;
        pow = 00;
        items = new List<ItemInfo>() { new ItemInfo() { id = 1, num = 1 } };//给一些初始值
        equips= new List<ItemInfo>() { new ItemInfo() { id = 3, num = 10 } };
        gems = new List<ItemInfo>();
    }
}

/// <summary>
/// 玩家拥有的道具基础信息
/// </summary>

[System.Serializable]
public class ItemInfo
{
    public int id;
    public int num;
}

/// <summary>
/// 临时结构体 用来表示道具信息的数据结构
/// </summary>
[System.Serializable]
public class Items
{
    public List<Item> info;
}

/// <summary>
/// 道具的基础信息数据结构
/// </summary>
[System.Serializable]//这样才能使用json解析
public class Item
{
    public int id;
    public string name;
    public string icon;
    public int type;
    public int price;
    public string tips;
}