using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(DebugCommandRunner))]
public class EditorCommandRunner : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DebugCommandRunner commandRunner = (DebugCommandRunner) target;
        var commandTypes = Enum.GetNames(typeof(CommandType));
        for(int i = 0; i < commandTypes.Length; i++)
        {
            var commandType = (CommandType)i;
            if (commandType == CommandType.UNDEFINED)
                continue;
            if (GUILayout.Button($"Run: {commandType}"))
            {
                var command = CommandCreator.Instance.GetCommandByType(commandType, commandRunner.Reciever);
                command.Args = new object[commandRunner.Args.Length];
                for(int j = 0; j < command.Args.Length; j++)
                {
                    var commandArg = commandRunner.Args[j];
                    int integerVal;
                    if(int.TryParse(commandArg, out integerVal))
                    {
                        command.Args[j] = integerVal;
                    } 
                    else
                    {
                        command.Args[j] = commandRunner.Args[j];
                    }               
                }
                command.DoAction();
            }
        }
        
    }

}
