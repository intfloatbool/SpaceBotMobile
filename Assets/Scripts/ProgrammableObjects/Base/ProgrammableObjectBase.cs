using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ProgrammableObjectBase : MonoBehaviour
{ 
    [SerializeField] protected Transform _marker;
    [SerializeField] protected CommandType _currentCommand = CommandType.UNDEFINED;
    protected Dictionary<CommandType, Action> _commandExecutorsDict = new Dictionary<CommandType, Action>();
    protected Dictionary<CommandType, object[]> _commandArgsDict = new Dictionary<CommandType, object[]>();
    protected Coroutine _currentCommandCoroutine;

    [SerializeField] private List<ScannableObject> _scannedObjects;

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
    /// Init default at first time, to add new commands just override it.. 
    /// </summary>
    protected virtual void InitializeCommands()
    {
        AddCommandExecutor(CommandType.RADAR, StartRadar);
    }


    protected virtual void AddCommandExecutor(CommandType cmdType, Action executor)
    {
        if(!_commandExecutorsDict.ContainsKey(cmdType))
        {
            _commandExecutorsDict.Add(cmdType, executor);
        } 
        else
        {
            Debug.LogWarning($"{cmdType} executor has been overwritten!");
            _commandExecutorsDict[cmdType] = executor;
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

    protected bool IsHasArgs()
    {
        var args = GetCurrentArgs();
        return args != null && args.Length > 0;
    }

    //Default commands actions
    protected virtual void StartRadar()
    {     
        var scanName = "UNKNOWN";
        if(IsHasArgs())
        {
            var currentArgs = GetCurrentArgs();
            if(currentArgs[0] is string)
                scanName = (string) currentArgs[0];
        }
        _scannedObjects = FindObjectsOfType<ScannableObject>()
            .ToList()
            .Where(s => s.ScanTag.Equals(scanName))
            .ToList();
    }
}
