using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RunProgrammBtn : MonoBehaviour
{
    private Button _btn;
    private ProgrammableObjectBase _programmableObject;
    private void Awake()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnClickBtn);
    }

    public void SetProgrammable(ProgrammableObjectBase programmable) => this._programmableObject = programmable;

    private void OnClickBtn()
    {
        CommandRunner.Instance.StartRunningCommands(_programmableObject);
    }
}
