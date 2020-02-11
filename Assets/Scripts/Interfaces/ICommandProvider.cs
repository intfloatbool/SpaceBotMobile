using System.Collections.Generic;

public interface ICommandProvider
{
    IEnumerable<CommandContainer> GetCommandContainers();
}
