using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgrammableGui : MonoBehaviour
{
    [SerializeField] private ProgrammableBtn[] _programmableButtons;
    [SerializeField] private TextMeshProUGUI _programmableNameText;
    [SerializeField] private ProgrammableObjectBase _selectedProgrammable;
    public ProgrammableObjectBase SelectedProgrammable => _selectedProgrammable;
    private void Start()
    {
        UserPicker.Instance.OnPick += OnRobotPick;
    }

    private void OnRobotPick(ControlableObject controlable)
    {  
        if(controlable is RobotControlable robotControlable)
        {
            for(int i = 0; i < _programmableButtons.Length; i++)
            {
                _programmableButtons[i].SetProgrammable(robotControlable.ProgrammableObject);
            }
            _programmableNameText.text = robotControlable.Name;
        }           
    }
}
