using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarCommand : CommandBase
{
    public override CommandType CommandType => CommandType.RADAR;

    public RadarCommand(ProgrammableObjectBase programmableObject, object[] args = null) : base(programmableObject, args) 
    { 
    
    }
}
