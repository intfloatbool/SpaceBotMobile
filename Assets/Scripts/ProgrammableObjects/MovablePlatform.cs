using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class MovablePlatform : ProgrammableObjectBase
{
    [SerializeField] private AICharacterControl _aiControl;
    [SerializeField] private float _rotationSpeed = 5;
    protected override void Awake()
    {
        base.Awake();
        _aiControl.SetTarget(_marker);
    }
    protected override void InitializeCommands()
    {
        _commandExecutorsDict.Add(CommandType.MOVE, StartMove);
        _commandExecutorsDict.Add(CommandType.ROTATE, StartRotation);
    }

    private void StartMove()
    {
        _currentCommandCoroutine = StartCoroutine(MoveCoroutine());
    }

    private void StartRotation()
    {
        _currentCommandCoroutine = StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        var args = GetCurrentArgs();
        var angleToRotate = transform.eulerAngles;
        if (args != null)
        {
            var angle = (int)args[0];
            angleToRotate += Vector3.up * angle;
        }

        while(transform.eulerAngles.y < angleToRotate.y)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angleToRotate), _rotationSpeed * Time.deltaTime);
            yield return null;
        }

        _currentCommandCoroutine = null;
        yield return null;
    }

    private IEnumerator MoveCoroutine()
    {
        var args = GetCurrentArgs();
        if(args != null)
        {
            var distance = (int) args[0];
            var posToGo = transform.position + transform.forward * distance;
            _marker.transform.position = posToGo;
        }

        while (_aiControl.agent.remainingDistance > 0)
            yield return null;

        _currentCommandCoroutine = null;
        yield return null;     
    }
}
