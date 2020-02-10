using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSwitcher : MonoBehaviour
{
    [SerializeField] private ControlableObject _currentControlableObject;

    private void Start()
    {
        UserPicker.Instance.OnPick += OnPick;
    }

    private void OnPick(ControlableObject controlableObject)
    {
        if (_currentControlableObject != null)
            _currentControlableObject.OnStopControl();

        _currentControlableObject = controlableObject;
        _currentControlableObject.OnStartControl();
        SpaceCamera.Instance.StartMonitoring(_currentControlableObject);
    }
}
