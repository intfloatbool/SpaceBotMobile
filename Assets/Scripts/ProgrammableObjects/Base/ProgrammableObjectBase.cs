using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProgrammableObjectBase : MonoBehaviour
{ 
    [SerializeField] protected Transform _marker;
    [SerializeField] protected CommandType _currentCommand = CommandType.UNDEFINED;
    protected Dictionary<CommandType, Action> _commandExecutorsDict = new Dictionary<CommandType, Action>();
    protected Dictionary<CommandType, object[]> _commandArgsDict = new Dictionary<CommandType, object[]>();
    protected Coroutine _currentCommandCoroutine;
    
    protected virtual void Awake()
    {
        InitializeCommands();
        CreateMarker();
    }
    protected virtual void CreateMarker()
    {
        _marker = new GameObject().transform;
        _marker.name = $"{gameObject.name}_marker";
        _marker.transform.position = transform.position;
    }
    /// <summary>
    /// Init commands at first time
    /// </summary>
    protected abstract void InitializeCommands();

    protected virtual void AddCommandExecutor(CommandType cmdType, Action executor)
    {
        if(!_commandExecutorsDict.ContainsKey(cmdType))
        {
            _commandExecutorsDict.Add(cmdType, executor);
        } 
        else
        {
            Debug.LogError($"Cannot add command executor for {cmdType}, already exists!");
        }
    }

    protected virtual object[] GetCurrentArgs()
    {
        return _commandArgsDict.ContainsKey(_currentCommand) ? _commandArgsDict[_currentCommand] : null;
    }

    public virtual bool ExecuteCommand(CommandType cmdType, object[] args)
    {
        if (_commandExecutorsDict.ContainsKey(cmdType))
        {
            _currentCommand = cmdType;
            if (_currentCommandCoroutine != null)
            {
                Debug.LogWarning("Previous command has been stopped!");
                StopCoroutine(_currentCommandCoroutine);
                _currentCommandCoroutine = null;
            }
            var commandAction = _commandExecutorsDict[cmdType];
            _commandArgsDict[cmdType] = args;
            commandAction();
            return true;
        }
        Debug.LogError($"Cannot execute command {cmdType}, not found!");
        return false;
    }
}
