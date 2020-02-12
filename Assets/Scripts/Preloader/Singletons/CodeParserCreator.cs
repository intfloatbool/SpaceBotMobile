using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CodeParserCreator : PreloadSingleton<CodeParserCreator>
{
    [SerializeField] private CodeParserType _currentCodeParserType = CodeParserType.SIMPLE;
    [SerializeField] private List<CodeParserBase> _parserPrefabs;
    private CodeParserBase _currentParser;
    protected override CodeParserCreator GetInstance() => this;

    protected override void Awake()
    {
        base.Awake();

        _currentParser = CreateCurrentParser();
        if(_currentParser == null)
        {
            Debug.LogError($"Cannot create code parser with type {_currentCodeParserType}! Not exists.");
        }
    }

    private CodeParserBase CreateCurrentParser()
    {
        var prefab = _parserPrefabs.FirstOrDefault(p => p.CodeParserType == _currentCodeParserType);
        var instance = Instantiate(prefab, transform);
        return instance;
    }

    public CodeParserBase GetCurrentParser() => _currentParser;
}
