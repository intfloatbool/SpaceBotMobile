using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiHandler : SingletonBase<GuiHandler>
{   
    public enum GuiType
    {
        UNDEFINED,
        Player,
        ProgrammableUnits
    }

    [System.Serializable]
    public class GuiContainer
    {
        public GuiType GuiType;
        public List<GameObject> GameObjects;     
    }

    private Dictionary<GuiType, GuiContainer> _guiDict = new Dictionary<GuiType, GuiContainer>();

    [SerializeField] private GuiType _currentGui;
    [SerializeField] private List<GuiContainer> _guiContainers;
    protected override GuiHandler GetInstance() => this;

    protected override void Awake()
    {
        base.Awake();
        InitDict();
    }

    private void InitDict()
    {
        foreach(var gui in _guiContainers)
        {
            if (!_guiDict.ContainsKey(gui.GuiType))
            {
                _guiDict.Add(gui.GuiType, gui);
            }
            else
            {
                Debug.LogError($"Gui with type {gui.GuiType} already exists!");
            }
        }
    }

    private GuiContainer GetGui(GuiType guiType)
    {
        return _guiDict.ContainsKey(guiType) ? _guiDict[guiType] : null;
    }

    public void ActivateGuiByType(GuiType guiType)
    {
        var currentGui = GetGui(_currentGui);
        if(currentGui != null)
        {
            currentGui.GameObjects.ForEach(g => g.SetActive(false));
        }
        var newGui = GetGui(guiType);
        if (newGui != null)
        {
            newGui.GameObjects.ForEach(g => g.SetActive(true));
            _currentGui = guiType;
        }
    }
}
