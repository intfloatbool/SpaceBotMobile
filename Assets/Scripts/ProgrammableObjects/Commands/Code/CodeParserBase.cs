using System.Collections.Generic;
using UnityEngine;

public abstract class CodeParserBase : MonoBehaviour
{
    public abstract CodeParserType CodeParserType { get; }
    public abstract List<CommandContainer> ParseText(string text);
}
