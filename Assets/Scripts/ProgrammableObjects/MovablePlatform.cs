﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class MovablePlatform : ProgrammableObjectBase
{
    [SerializeField] private ObjectMover _objectMover;
    [SerializeField] private float _rotationSpeed = 5;
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

        while(transform.eulerAngles.y < angleToRotate.y)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angleToRotate), _rotationSpeed * Time.deltaTime);
            yield return null;
        }
        transform.eulerAngles = angleToRotate;
        _currentCommandCoroutine = null;
        yield return null;
    }

    protected virtual IEnumerator MoveCoroutine()
    {
        var args = GetCurrentArgs();
        if(args != null)
        {
            var distance = (int) args[0];
            var posToGo = transform.position + transform.forward * distance;
            _marker.transform.position = posToGo;
            _objectMover.MovePos = _marker.transform.position;
            _objectMover.IsActive = true;
        }

        while (!_objectMover.IsReachTarget)
            yield return null;

        _currentCommandCoroutine = null;
        _objectMover.IsActive = false;
        yield return null;     
    }
}
