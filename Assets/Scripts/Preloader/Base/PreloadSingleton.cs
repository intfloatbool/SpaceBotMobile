using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PreloadSingleton<T> : SingletonBase<T>
{
    protected override void Awake()
    {
        base.Awake();
        this.gameObject.AddComponent<DontDestroyOnLoadComponent>();
    }
}
