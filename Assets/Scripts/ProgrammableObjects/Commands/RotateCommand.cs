using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : CommandBase
{
    public override CommandType CommandType => CommandType.ROTATE;

    public RotateCommand(ProgrammableObjectBase programmableObject, object[] args = null) : base(programmableObject, args)
    {

    }
}
