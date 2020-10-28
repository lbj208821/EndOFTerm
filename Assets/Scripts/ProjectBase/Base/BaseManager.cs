using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager<T>where T:new()//约束，满足无参构造函数
{
    
        private static T instance;
        public static T  GetInstance()
        {
            if (instance == null)//保证唯一性
                instance = new T();
            return instance;
        }
  
}
 
