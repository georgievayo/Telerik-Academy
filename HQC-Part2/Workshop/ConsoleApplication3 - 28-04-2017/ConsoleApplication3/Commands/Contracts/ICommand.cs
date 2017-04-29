using System.Collections.Generic;

namespace SchoolSystem.Models
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
