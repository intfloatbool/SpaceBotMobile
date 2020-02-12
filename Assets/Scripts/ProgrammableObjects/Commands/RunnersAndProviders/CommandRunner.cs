using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandRunner : SingletonBase<CommandRunner>
{
    [SerializeField] private bool _isRunningOnStartup;
    [SerializeField] private ProgrammableObjectBase _currentProgramamble;
    [SerializeField] private string[] _currentArgs;
    protected override CommandRunner GetInstance() => this;

    private Coroutine _currentCommandsCoroutine;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        if(_isRunningOnStartup && _currentProgramamble != null)
        {
            StartRunningCommands(_currentProgramamble);
        }
    }

    [ContextMenu("StartRunningCommandsWithSelectedObject")]
    public void StartRunningCommandsWithSelectedObject()
    {
        if(_currentProgramamble == null)
        {
            Debug.LogError("Select current programmableObject to run!");
            return;
        }
        StartRunningCommands(_currentProgramamble);
    }

    public void StartRunningCommands(ProgrammableObjectBase programmableObject)
    {
        if(_currentCommandsCoroutine != null)
        {
            Debug.LogWarning("Current commands not done! Stop current and start new one!");
            StopCoroutine(_currentCommandsCoroutine);
            _currentCommandsCoroutine = null;
        }
        _currentProgramamble = programmableObject;
        _currentCommandsCoroutine = StartCoroutine(StartRunningCommandsCoroutine());
        
    }

    private IEnumerator StartRunningCommandsCoroutine()
    {
        var commands = _currentProgramamble.CommandProvider.GetCommandContainers();
        if(commands == null)
        {
            Debug.LogError("Cannot get commands from provider!");
            yield break;
        }

        foreach(var commandContainer in commands)
        {
            var commandType = commandContainer.CommandType;
            var args = commandContainer.GetPackedArgs();
            _currentArgs = commandContainer.ArgsStr;
            var command = CommandCreator.Instance.GetCommandByType(commandType, _currentProgramamble, args);
            command.DoAction();
            var reciever = command.Reciever;
            while(reciever.IsExecuting)
            {
                yield return null;
            }
        }
    }

}
