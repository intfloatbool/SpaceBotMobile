using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayerPickerButton : MonoBehaviour
{
    private Button _btn;
    private ControlableObject _player;
    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(PickPlayer);
    }

    private void PickPlayer()
    {
        if(_player == null)
        {
            var playerObject = GameObject.FindGameObjectWithTag("Player");
            _player = playerObject.GetComponent<ControlableObject>();
        }

        if(_player != null)
        {
            UserPicker.Instance.Pick(_player);
        }

    }
}
