using System.Collections.Generic;
using UnityEngine;

public class DebugCommandProvider : CommandProviderBase
{
    [SerializeField] private CommandContainer[] _commandContainers;
    public override IEnumerable<CommandContainer> GetCommandContainers()
    {
        return _commandContainers;
    }
}
