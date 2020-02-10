using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPicker : SingletonBase<UserPicker>
{
    public event Action<ControlableObject> OnPick = (controlable) => { };
    public void Pick(ControlableObject controlable)
    {
        OnPick(controlable);
    }
    void Update()
    {
        HandleUserInputFromCamera();
    }

    private void HandleUserInputFromCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = SpaceCamera.Instance.Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var controlableObject = hit.collider.gameObject.GetComponent<ControlableObject>();
                if (controlableObject != null)
                {
                    Pick(controlableObject);
                }
            }
        }
    }

    protected override UserPicker GetInstance() => this;
}
