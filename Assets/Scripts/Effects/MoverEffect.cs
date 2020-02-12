using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEffect : MonoBehaviour
{
    [SerializeField] private ObjectMover _objectMover;
    [SerializeField] private List<GameObject> _effectObjects;
    private void Awake()
    {
        _objectMover.OnActiveChanged += OnMoverChanged;
    }

    private void OnMoverChanged(bool isActive)
    {
        _effectObjects.ForEach(g => g.SetActive(isActive));
    }
}
