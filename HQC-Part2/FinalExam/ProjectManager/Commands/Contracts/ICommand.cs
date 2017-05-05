using System.Collections.Generic;

namespace ProjectManager.Core.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
