﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class MovablePlatform : ProgrammableObjectBase
{
    [SerializeField] protected ObjectMover _objectMover;
    [SerializeField] protected float _rotationSpeed = 5f;
    protected override void InitializeCommands()
    {
        base.InitializeCommands();
        AddCommandExecutor(CommandType.MOVE, StartMove);
        AddCommandExecutor(CommandType.ROTATE, StartRotation);
    }

    protected virtual void StartMove()
    {
        _currentCommandCoroutine = StartCoroutine(MoveCoroutine());
    }

    protected virtual void StartRotation()
    {
        _currentCommandCoroutine = StartCoroutine(RotateCoroutine());
    }

    protected virtual IEnumerator RotateCoroutine()
    {
        
        var angleToRotate = transform.eulerAngles;
        if (IsHasArgs())
        {
            var args = GetCurrentArgs();
            var angle = (int)args[0];
            angleToRotate += Vector3.up * angle;
        }

        var eulerRotation = Quaternion.Euler(angleToRotate);
        var maxAngle = 1f;   
        while(Quaternion.Angle(Quaternion.Euler(transform.eulerAngles), eulerRotation) >
            maxAngle)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, eulerRotation, _rotationSpeed * Time.deltaTime);
            yield return null;
        }
        transform.eulerAngles = angleToRotate;
        yield return StartCoroutine(DelayedCommandReset());
    }

    protected virtual IEnumerator MoveCoroutine()
    {    
        if(IsHasArgs())
        {
            var args = GetCurrentArgs();
            if (args[0] is int)
            {
                var distance = (int)args[0];
                var posToGo = transform.position + transform.forward * distance;
                _marker.transform.position = posToGo;
                _objectMover.MovePos = _marker.transform.position;
                _objectMover.IsActive = true;
            } 
            else if (args[0] is string)
            {
                if (LastRadarTargetTag != null &&_nearestObject != null)
                {
                    _marker.transform.position = _nearestObject.transform.position;
                    _objectMover.MovePos = _marker.transform.position;
                    _objectMover.IsActive = true;
                    _objectMover.FacingTarget = _nearestObject.transform;

                    LastRadarTargetTag = null;
                }
                else
                {
                    Debug.LogError("No target to move! Run radar first to get target!");
                }
            }          
        }

        while (!_objectMover.IsReachTarget)
            yield return null;
        _objectMover.IsActive = false;
        _objectMover.FacingTarget = null;
        yield return StartCoroutine(DelayedCommandReset());  
    }

    protected override void OnCommandStop()
    {
        base.OnCommandStop();
        _objectMover.IsActive = false;
        _objectMover.FacingTarget = null;
    }
}
