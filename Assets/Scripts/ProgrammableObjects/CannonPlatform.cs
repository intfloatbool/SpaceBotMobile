using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPlatform : MovablePlatform
{
    [SerializeField] private FireableCannon _fireCannon;
    protected override void InitializeCommands()
    {
        base.InitializeCommands();
        AddCommandExecutor(CommandType.AIM_ROTATE, AimRotate);
    }

    protected virtual void AimRotate()
    {
        _currentCommandCoroutine = StartCoroutine(RotateCannon());
    }

    protected virtual IEnumerator RotateCannon()
    {
        var angleToRotate = _fireCannon.transform.localEulerAngles;
        if(IsHasArgs())
        {
            var args = GetCurrentArgs();
            var aimAngle = args[0];
            if(aimAngle is int)
            {
                angleToRotate += Vector3.up * (int)aimAngle;
            }
        }

        while(_fireCannon.transform.localEulerAngles.y < angleToRotate.y)
        {
            _fireCannon.transform.localRotation = Quaternion.Lerp(_fireCannon.transform.localRotation, Quaternion.Euler(angleToRotate), _rotationSpeed * Time.deltaTime);
            yield return null;
        }
        _fireCannon.transform.localEulerAngles = angleToRotate;

        yield return null;
        _currentCommandCoroutine = null;
    }

}
