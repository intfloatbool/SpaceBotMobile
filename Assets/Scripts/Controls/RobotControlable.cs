using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControlable : ControlableObject
{
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
