using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRunnerBase : SingletonBase<CommandRunnerBase>
{
    [SerializeField] private ProgrammableObjectBase _currentProgramamble;
    [SerializeField] private string[] _currentArgs;
    [SerializeField] private CommandProviderBase _commandProvider;
    protected override CommandRunnerBase GetInstance() => this;

    protected override void Awake()
    {
        base.Awake();
    }

    public void StartRunningCommands(ProgrammableObjectBase programmableObject)
    {
        _currentProgramamble = programmableObject;
        
    }

}
