using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCodeParser : CodeParserBase
{
    public override CodeParserType CodeParserType => CodeParserType.SIMPLE;

    public override List<CommandContainer> ParseText(string text)
    {
        var listOfCommands = new List<CommandContainer>();
        var startCarret = "{";
        var endCarret = "}";
        var startCarretIndex = text.IndexOf(startCarret) + 1;
        var endCarretIndex = text.IndexOf(endCarret);
        var codeInside = text.Substring(startCarretIndex, endCarretIndex - startCarretIndex);
        var commandLines = codeInside.Split('\n');
        foreach(var line in commandLines)
        {
            var trimmed = line.Trim();
            if (string.IsNullOrEmpty(trimmed))
            {
                continue;
            }
               
            var command = CodeSyntaxHelper.Instance.GetCommandContainerByString(ProgrammableObject,
            trimmed);
            if (command != null)
            {
                listOfCommands.Add(command);
            }
            else
            {
                Debug.LogWarning($"Cannot create command by line {trimmed}!");
            }
                
        }
        return listOfCommands;
    }
}
