using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeEditor : SingletonBase<CodeEditor>
{
    [SerializeField] private Transform _guiBody;
    [SerializeField] private TMP_InputField _inputField;
    protected override CodeEditor GetInstance() => this;

    [SerializeField] private CodeCommandProvider _codeProvider;
    public CodeCommandProvider CodeProvider
    {
        get { return _codeProvider; }
        set { this._codeProvider = value; }
    }

    public void Hide()
    {
        SetActiveEditor(false);
    }

    public void Show()
    {
        SetActiveEditor(true);
    }

    private void SetActiveEditor(bool isActive)
    {
        _guiBody.gameObject.SetActive(isActive);
    }

    public void UpdateTextByCodeProvider()
    {
        var providerText = _codeProvider.GetCommandCode();
        if(string.IsNullOrEmpty(providerText))
        {
            var codeObjectName = _codeProvider.transform.root.name;
            var objectBodyText = $"World.{codeObjectName}.Actions" + "{\n\n}";
            providerText = objectBodyText;
        }
        _inputField.text = providerText;
    }

    public void SaveCodeToProvider()
    {
        _codeProvider.SetCommandCode(_inputField.text);
    }
}
