using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ProgrammableBtn : MonoBehaviour
{
    protected Button _btn;
    protected ProgrammableObjectBase _programmableObject;
    protected virtual void Awake()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnClickBtn);
    }

    public void SetProgrammable(ProgrammableObjectBase programmable) => this._programmableObject = programmable;

    protected virtual void OnClickBtn()
    {
        CommandRunner.Instance.StartRunningCommands(_programmableObject);
    }
}
