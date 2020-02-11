using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlableObject : MonoBehaviour
{
    [SerializeField] protected string _name;
    public string Name => _name;

    [SerializeField] protected UnityEvent _onControlStarted;
    [SerializeField] protected UnityEvent _onControlStopped;

    [SerializeField] protected Vector3 _localCamPos;
    public Vector3 LocalCamPos => _localCamPos;
    [SerializeField] protected Vector3 _localCamRot;
    public Vector3 LocalCamRot => _localCamRot;

    public virtual void OnStartControl()
    {
        _onControlStarted.Invoke();
    }

    public virtual void OnStopControl()
    {
        _onControlStopped.Invoke();
    }

}
