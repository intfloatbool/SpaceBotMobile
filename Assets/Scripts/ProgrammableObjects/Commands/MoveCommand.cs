using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : CommandBase
{
    public override CommandType CommandType => CommandType.MOVE;

    public MoveCommand(ProgrammableObjectBase programmableObject, object[] args = null): base(programmableObject, args)
    {
        
    }
}
