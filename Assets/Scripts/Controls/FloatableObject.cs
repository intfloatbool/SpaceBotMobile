using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatableObject : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotSpeed = 5f;

    [SerializeField] private bool _isActive;
    public bool IsActive
    {
        get { return _isActive; }
        set { this._isActive = value; }
    }

    [SerializeField] private Vector3 _targetLocalPos;
    public Vector3 TargetLocalPos
    {
        get { return _targetLocalPos; }
        set { this._targetLocalPos = value; }
    }

    [SerializeField] private Vector3 _targetLocalEuler;
    public Vector3 TargetLocalEuler
    {
        get { return _targetLocalEuler; }
        set { this._targetLocalEuler = value; }
    }

    private void Update()
    {
        if (!_isActive)
            return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, _targetLocalPos, _moveSpeed * Time.deltaTime);
        transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, _targetLocalEuler, _rotSpeed * Time.deltaTime);
    }
}
