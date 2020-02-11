using UnityEngine;

[System.Serializable]
public class CommandContainer 
{
    [SerializeField] private CommandType _commandType;
    public CommandType CommandType
    {
        get { return _commandType; }
        set { this._commandType = value; }
    }

    [SerializeField] private string[] _args;
    public string[] ArgsStr
    {
        get { return _args; }
        set { this._args = value; }
    }

    /// <summary>
    /// Packed args with parsed int and strings from ArgsStr property
    /// </summary>
    public object[] GetPackedArgs()
    {
        var argsArr = new object[_args.Length];
        for (int j = 0; j < argsArr.Length; j++)
        {
            int integerVal;
            if (int.TryParse(_args[j], out integerVal))
            {
                argsArr[j] = integerVal;
            }
            else
            {
                argsArr[j] = _args[j];
            }
        }

        return argsArr;
    }
    
}
