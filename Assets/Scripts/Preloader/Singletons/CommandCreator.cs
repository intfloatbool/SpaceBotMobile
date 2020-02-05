using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCreator : PreloadSingleton<CommandCreator>
{
    [Header("target object for test")]
    [SerializeField] private ProgrammableObjectBase _programmableObject;
    public ProgrammableObjectBase ProgrammableObject => _programmableObject;

    [Header("target command args for test")]
    [SerializeField] private int[] _args;
    public int[] Args => _args;

    protected override CommandCreator GetInstance() => this;
    protected override void Awake()
    {
        base.Awake();
    }

    public CommandBase GetCommandByType(CommandType cmdType, ProgrammableObjectBase programableObject)
    {
        switch(cmdType)
        {
            case CommandType.MOVE:
                {
                    return new MoveCommand(programableObject);
                }
            case CommandType.ROTATE:
                {
                    return new RotateCommand(programableObject);
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
