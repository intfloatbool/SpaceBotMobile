using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectMover : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 5f;
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { this._moveSpeed = value; }
    }

    [SerializeField] private float _rotationSpeed = 5f;
    public float RotationSpeed
    {
        get { return _rotationSpeed; }
        set { this._rotationSpeed = value; }
    }
    private Rigidbody _rb;
    public Rigidbody Rb => _rb;

    [SerializeField] private Vector3 _movePos;
    public Vector3 MovePos
    {
        get { return _movePos; }
        set { this._movePos = value; }
    }

    [SerializeField] private bool _isActive;
    public bool IsActive 
    {
        get { return _isActive; }
        set 
        {
            this._isActive = value;
            OnActiveChanged(this._isActive);
        }
    }

    public event Action<bool> OnActiveChanged = (isActive) => { };

    [SerializeField] private float _stoppingDIstance = 1f;
    public bool IsReachTarget => Vector3.Distance(transform.position, MovePos) <= _stoppingDIstance;

    public Transform FacingTarget { get; set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        MovePos = transform.position;
    }

    private void FixedUpdate()
    {
        if (!_isActive)
        {
            return;
        }
        var transformedMovePos = new Vector3(MovePos.x, transform.position.y, MovePos.z);
        var relativePos = transformedMovePos - transform.position;

        if (FacingTarget != null)
        {
            var lookRot = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, _rotationSpeed * Time.fixedDeltaTime);
        }                
        
        var move = transform.InverseTransformDirection(relativePos);
        transform.Translate(move.normalized * _moveSpeed * Time.fixedDeltaTime);
    }

}
