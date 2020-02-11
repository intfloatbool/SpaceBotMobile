using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgrammableObjectBase))]
public class RobotControlable : ControlableObject
{
    private ProgrammableObjectBase _prorgammableObject;
    public ProgrammableObjectBase ProgrammableObject => _prorgammableObject;

    private void Awake()
    {
        _prorgammableObject = GetComponent<ProgrammableObjectBase>();
    }

    public override void OnStartControl()
    {
        base.OnStartControl();
        GuiHandler.Instance.ActivateGuiByType(GuiHandler.GuiType.ProgrammableUnits);
    }

    public override void OnStopControl()
    {
        base.OnStopControl();
    }
}
