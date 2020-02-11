using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandProviderBase : MonoBehaviour, ICommandProvider
{
    public abstract IEnumerable<CommandContainer> GetCommandContainers();
}
