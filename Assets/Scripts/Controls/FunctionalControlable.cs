using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunctionalControlable : ControlableObject
{
    [System.Serializable]
    public class DependingObject
    {
        public GameObject GameObject;
        public bool IsInversed;
    }

    [System.Serializable]
    public class DependingImage
    {
        public Image Image;
        public bool IsInversed;
    }
    [SerializeField] private List<DependingObject> _dependingObjects;
    [SerializeField] private List<DependingImage> _dependingImages;
    public override void OnStartControl()
    {
        base.OnStartControl();
        GuiHandler.Instance.ActivateGuiByType(GuiHandler.GuiType.Player);
        SetActiveDepends(true);
    }

    public override void OnStopControl()
    {
        base.OnStopControl();
        SetActiveDepends(false);
    }

    private void SetActiveDepends(bool isActive)
    {
        _dependingObjects.ForEach(d => {
            if (d.IsInversed)
                d.GameObject.SetActive(!isActive);
            else
                d.GameObject.SetActive(isActive);
        });
        _dependingImages.ForEach(d => {
            if (d.IsInversed)
                d.Image.enabled = !isActive;
            else
                d.Image.enabled = isActive;
        });
    }
}
