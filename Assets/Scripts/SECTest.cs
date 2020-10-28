using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SECTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PoolMgr.GetInstance().GetObj("Test/Cube" ,(obj)=>{ Debug.Log("实例化了1"); });
        }
        if (Input.GetMouseButtonDown(1))
        {
            PoolMgr.GetInstance().GetObj("Test/Sphere", (obj) => { Debug.Log("实例化了2"); });
        }
    }
}
