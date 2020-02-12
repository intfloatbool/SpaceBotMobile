using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCommandProvider : CommandProviderBase
{
    private string _currentCodeText;
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
        return CodeParserCreator.Instance.GetCurrentParser().ParseText(_currentCodeText);
    }
}
