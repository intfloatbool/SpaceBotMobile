using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    [SerializeField] private GameObject[] _preloadObjectPrefabs;
    [SerializeField] private float _initializeDelay = 0.5f;

    public event Action OnPreloaderFinished = () => { };

    private IEnumerator Start()
    {
        yield return StartCoroutine(InitializePreloadersCoroutine());
        OnPreloaderFinished();
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
