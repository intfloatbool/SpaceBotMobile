using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Preloader : MonoBehaviour, IDonebleAction
{
    [SerializeField] private GameObject[] _preloadObjectPrefabs;
    [SerializeField] private float _initializeDelay = 0.5f;
    [SerializeField] private UnityEvent _onPreloadDoneEvent;

    public event Action OnDone = () => { };

    private IEnumerator Start()
    {
        yield return StartCoroutine(InitializePreloadersCoroutine());
        OnDone();
        _onPreloadDoneEvent.Invoke();
    }

    private IEnumerator InitializePreloadersCoroutine()
    {
        var delay = new WaitForSeconds(_initializeDelay);
        for(int i = 0; i < _preloadObjectPrefabs.Length; i++)
        {
            var objPrefab = _preloadObjectPrefabs[i];
            Instantiate(objPrefab);
            yield return delay;
        }      
    }
}
