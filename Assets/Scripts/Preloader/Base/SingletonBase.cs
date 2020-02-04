using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonBase<T> : MonoBehaviour
{
    public static T Instance { get; protected set; }
    
    protected virtual void Awake()
    {
        if(Instance == null)
        {
            Instance = GetInstance();
        } 
        else
        {
            Destroy(gameObject);
            Debug.LogError($"Some instance already exists of {typeof(T)} !");
        }
    }

    protected abstract T GetInstance();
}
