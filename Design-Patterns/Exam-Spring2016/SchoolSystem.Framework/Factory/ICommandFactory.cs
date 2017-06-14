using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Factory
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string command);
    }
}
