using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPush : MonoBehaviour
{
    // Start is called before the first frame update
    //当对象激活时，会进入的生命周期函数
    void OnEnable()
    {
        Invoke("Push", 1);   
    }

    // Update is called once per frame
    void Push()
    {
        PoolMgr.GetInstance().PushObj(this.gameObject.name, this.gameObject);
    }
}
