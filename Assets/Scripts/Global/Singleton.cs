using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>
{
    private static T instance;

    //private T()
    //{
    //}

    //public static T Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = new T();
    //        }
    //        return instance;
    //    }
    //}
}



public class SingletonMonoBehaviour<T> : MonoBehaviour
    where T : MonoBehaviour //对T使用where进行约束，泛型T必须继承自MonoBehaviour
{
    private static T m_instance;

    public static T Instance
    {
        get
        {
            return m_instance;
        }
    }

    protected virtual void Awake()
    {
        m_instance = this as T;
    }
}
