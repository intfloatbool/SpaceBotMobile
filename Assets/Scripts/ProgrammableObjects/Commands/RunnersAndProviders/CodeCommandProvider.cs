using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCommandProvider : CommandProviderBase
{
    [SerializeField] private ProgrammableObjectBase _progrmmable;

    [TextArea]
    [SerializeField] private string _currentCodeText;
    public void SetCommandCode(string code)
    {
        this._currentCodeText = code;
    }

    public string GetCommandCode()
    {
        return this._currentCodeText;
    }
    public override IEnumerable<CommandContainer> GetCommandContainers()
    {
        var parser = CodeParserCreator.Instance.GetCurrentParser();
        parser.ProgrammableObject = _progrmmable;
        if(parser.ProgrammableObject == null)
        {
            Debug.LogError("Programmable object not found!!");
        }
        return parser.ParseText(_currentCodeText);
    }
}
