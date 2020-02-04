using UnityEngine.UI;
using UnityEngine;

public class LoadingView : MonoBehaviour
{
    [SerializeField] private Image _loadingBarImg;
    [SerializeField] private Transform _loadingViewParent;
    [SerializeField] private float _barSpeed = 5f;
    private SceneLoader _sceneLoader;
    private bool _isProgressStarted = false;

    private void Start()
    {
        this._sceneLoader = SceneLoader.Instance;
        if(this._sceneLoader == null)
        {
            Debug.LogError("Cannot find SceneLoader!");
            return;
        }

        _sceneLoader.OnSceneBeginDownloading += (sceneType) =>
        {
            StartProgress();
        };
        _sceneLoader.OnSceneFinishDownloading += (sceneType) =>
        {
            StopProgress();
        };
    }

    private void StartProgress()
    {
        SetActiveProgressMoving(true);
        ResetBarFill();
        SetActiveCanvas(true);
    }

    private void StopProgress()
    {
        SetActiveProgressMoving(false);
        ResetBarFill();
        SetActiveCanvas(false);
    }

    private void ResetBarFill() => 
        _loadingBarImg.fillAmount = 0;
    private void SetActiveProgressMoving(bool isActive) =>
        _isProgressStarted = isActive;
    private void SetActiveCanvas(bool isActive) => 
        _loadingViewParent.gameObject.SetActive(isActive);

    private void Update()
    {
        if (!_isProgressStarted)
            return;

        _loadingBarImg.fillAmount = Mathf.Lerp(_loadingBarImg.fillAmount, _sceneLoader.CurrentProgress, _barSpeed * Time.deltaTime);
    }
}
