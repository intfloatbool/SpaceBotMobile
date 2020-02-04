using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class ExitBtn : MonoBehaviour
{
    private Button _btn;

    private void Awake()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(Application.Quit);
    }
}
