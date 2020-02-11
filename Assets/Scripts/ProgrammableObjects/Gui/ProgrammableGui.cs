using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgrammableGui : MonoBehaviour
{
    [SerializeField] private RunProgrammBtn _runProgrammButton;
    [SerializeField] private TextMeshProUGUI _programmableNameText;
    private void Start()
    {
        UserPicker.Instance.OnPick += OnRobotPick;
    }

    private void OnRobotPick(ControlableObject controlable)
    {  
        if(controlable is RobotControlable robotControlable)
        {
            _runProgrammButton.SetProgrammable(robotControlable.ProgrammableObject);
            _programmableNameText.text = robotControlable.Name;
        }           
    }
}
