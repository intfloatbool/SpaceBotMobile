using UnityEngine;

[RequireComponent(typeof(FloatableObject))]
[RequireComponent(typeof(Camera))]
public class SpaceCamera : SingletonBase<SpaceCamera>
{
    [SerializeField] private ControlableObject _defaultControlableObject;
    private FloatableObject _floatableObject;
    private Camera _camera;
    public Camera Camera => _camera;

    protected override SpaceCamera GetInstance() => this;

    protected override void Awake()
    {
        base.Awake();
        _floatableObject = GetComponent<FloatableObject>();
        _camera = GetComponent<Camera>();

        if (_defaultControlableObject != null)
            StartMonitoring(_defaultControlableObject);
    }

    public void StartMonitoring(ControlableObject controlableObject)
    {
        transform.parent = controlableObject.transform;
        _floatableObject.IsActive = true;
        _floatableObject.TargetLocalPos = controlableObject.LocalCamPos;
        _floatableObject.TargetLocalEuler = controlableObject.LocalCamRot;
    }

}
