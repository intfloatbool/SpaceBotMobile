using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCreator : PreloadSingleton<CommandCreator>
{
    [Header("target object for test")]
    [SerializeField] private ProgrammableObjectBase _programmableObject;
    public ProgrammableObjectBase ProgrammableObject => _programmableObject;

    [Header("target command args for test")]
    [SerializeField] private string[] _args;
    public string[] Args => _args;

    protected override CommandCreator GetInstance() => this;
    protected override void Awake()
    {
        base.Awake();
    }

    public CommandBase GetCommandByType(CommandType cmdType, ProgrammableObjectBase programableObject, object[] args = null)
    {
        switch(cmdType)
        {
            case CommandType.MOVE:
                {
                    return new MoveCommand(programableObject, args);
                }
            case CommandType.ROTATE:
                {
                    return new RotateCommand(programableObject, args);
                }
            case CommandType.RADAR:
                {
                    return new RadarCommand(programableObject, args);
                }
            case CommandType.AIM_ROTATE:
                {
                    return new AimRotateCommand(programableObject, args);
                }
            case CommandType.FIRE:
                {
                    return new FireCommand(programableObject, args);
                }

            default:
                {
                    Debug.LogError($"Command with type {cmdType} not exists!");
                    break;
                }
        }

        return null;
    }

}
