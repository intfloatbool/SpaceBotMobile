using System.Collections.Generic;
using UnityEngine;
using System;

public class CodeSyntaxHelper : PreloadSingleton<CodeSyntaxHelper>
{
    [SerializeField] private List<SyntaxContainer> _syntaxContainers;
    private Dictionary<string, SyntaxContainer> _syntaxDict = new Dictionary<string, SyntaxContainer>();

    protected override CodeSyntaxHelper GetInstance() => this;

    [Obsolete]
    [SerializeField] private CommandContainer _lastCommandContainer;

    protected override void Awake()
    {
        base.Awake();
        InitDict();
    }

    private void InitDict()
    {
        foreach(var syntaxContainer in _syntaxContainers)
        {
            var keyName = syntaxContainer.Name;
            if(!_syntaxDict.ContainsKey(keyName))
            {
                _syntaxDict.Add(keyName, syntaxContainer);
            }
            else
            {
                Debug.LogError($"SyntaxContainer with key name: {keyName} already defined!");
            }
        }
    }

    [ContextMenu("TestCommandContainer")]
    public void TestCommandContainer()
    {
        GetCommandContainerByString(null, "Fire()");
    }

    public CommandContainer GetCommandContainerByString(ProgrammableObjectBase programmable, string commandLine)
    {
        try
        {
            var indexOfStartArg = commandLine.IndexOf("(") + 1;
            var funcName = commandLine.Substring(0, indexOfStartArg - 1);
            var indexOfEndArg = commandLine.IndexOf(")");
            var argsStr = commandLine.Substring(indexOfStartArg, indexOfEndArg - indexOfStartArg);

            if (_syntaxDict.ContainsKey(funcName))
            {
                var syntaxContainer = _syntaxDict[funcName];
                var cmdType = syntaxContainer.CommandType;
                var commandContainer = new CommandContainer();
                if(!string.IsNullOrEmpty(argsStr))
                {
                    commandContainer.ArgsStr = new string[] { argsStr };
                }           
                commandContainer.CommandType = cmdType;
                _lastCommandContainer = commandContainer;
                return commandContainer;
            }
            else
            {
                Debug.LogError($"Cannot parse function, no key defined! : {funcName}");
            }
        } 
        catch(Exception ex)
        {
            Debug.LogError($"Cannot recongize syntax! \n {ex.Message} \n {ex.StackTrace}");
            return null;
        }

        return null;
    }

    /// <summary>
    /// IN PROCESS.
    /// </summary>
    /// <param name="strArgs"></param>
    /// <param name="argsType"></param>
    /// <returns></returns>
    private object[] ParseArgsByType(string strArgs, ArgsType argsType)
    {
        //TODO COMPLETE LOGIC.
        var args = new object[0];
        if (argsType == ArgsType.INTEGER)
        {
            int parsedInt;
            if(int.TryParse(strArgs, out parsedInt))
            {
                args[0] = parsedInt;
            } 
            else
            {
                args = null;
                Debug.LogError($"cannot parse! For {argsType} type!");
            }
        }
        else if (argsType == ArgsType.STRING)
        {
            args[0] = strArgs;
        }
        else
        {
            args = null;
        }

        return args;
    }
}
