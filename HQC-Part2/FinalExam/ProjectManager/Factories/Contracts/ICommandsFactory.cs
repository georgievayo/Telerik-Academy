using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Core.Contracts;

namespace ProjectManager.Factories.Contracts
{
    /// <summary>
    /// Factory for creating commands
    /// </summary>
    public interface ICommandsFactory
    {
        /// <summary>
        /// Converts a string to command
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns>ICommand</returns>
        ICommand CreateCommandFromString(string commandName);
    }
}
