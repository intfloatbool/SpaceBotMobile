using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPlatform : MovablePlatform
{
    [SerializeField] private float _fireDelay = 1.5f;
    [SerializeField] private FireableCannon _fireCannon;
    protected override void InitializeCommands()
    {
        base.InitializeCommands();
        AddCommandExecutor(CommandType.AIM_ROTATE, AimRotate);
        AddCommandExecutor(CommandType.FIRE, FireCannon);
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

        var maxAngle = 1f;
        
        while(Quaternion.Angle(Quaternion.Euler(_fireCannon.transform.localEulerAngles),
            Quaternion.Euler(angleToRotate)) >= maxAngle)
        {
            _fireCannon.transform.localRotation = Quaternion.Lerp(_fireCannon.transform.localRotation, Quaternion.Euler(angleToRotate), _rotationSpeed * Time.deltaTime);
            yield return null;
        }
        _fireCannon.transform.localEulerAngles = angleToRotate;

        yield return StartCoroutine(DelayedCommandReset());
    }

    protected virtual void FireCannon()
    {
        _currentCommandCoroutine = StartCoroutine(FireCannonCoroutine());
    }

    protected virtual IEnumerator FireCannonCoroutine()
    {
        yield return new WaitForSeconds(_fireDelay);
        _fireCannon.Fire();
        yield return StartCoroutine(DelayedCommandReset());
    }

}
