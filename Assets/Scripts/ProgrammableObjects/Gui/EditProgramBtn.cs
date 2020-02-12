using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditProgramBtn : ProgrammableBtn
{
    protected override void OnClickBtn()
    {
        var commandProvider = _programmableObject.CommandProvider;
        if(commandProvider == null)
        {
            Debug.LogError("Command provider is null!");
            return;
        }

        if(commandProvider is CodeCommandProvider codeCommandProvider)
        {
            CodeEditor.Instance.CodeProvider = codeCommandProvider;
            CodeEditor.Instance.Show();
            CodeEditor.Instance.UpdateTextByCodeProvider();
        }
        else
        {
            Debug.LogError("There is no codeCommandProvider!");
        }

    }
}
