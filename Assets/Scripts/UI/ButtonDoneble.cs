using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonDoneble : MonoBehaviour, IDonebleAction
{
    private Button _btn;
    public event Action OnDone = () => { };
    private void Awake()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnDone.Invoke);
    }
}
