using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCodeParser : CodeParserBase
{
    public override CodeParserType CodeParserType => CodeParserType.SIMPLE;

    public override List<CommandContainer> ParseText(string text)
    {
        Debug.Log("Try parse text: \n" + text);
        return null;
    }
}
