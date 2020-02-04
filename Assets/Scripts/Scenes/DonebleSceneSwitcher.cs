using UnityEngine;

[RequireComponent(typeof(IDonebleAction))]
public class DonebleSceneSwitcher : MonoBehaviour
{
    [SerializeField] private SceneType _sceneToGo;
    private IDonebleAction _donebleAction;
    private void Awake()
    {
        _donebleAction = GetComponent<IDonebleAction>();
        if(_donebleAction == null)
        {
            Debug.LogError($"Cannot get doneble action!");
            return;
        }

        _donebleAction.OnDone += OnDone;    
    }

    private void OnDone()
    {
        var sceneLoaderInstance = SceneLoader.Instance;
        if(sceneLoaderInstance == null)
        {
            Debug.LogError("Cannot find SceneLoader instance!");
            return;
        }

        sceneLoaderInstance.LoadScene(_sceneToGo);
    }
}
