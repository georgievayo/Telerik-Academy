using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Common.Contracts;

namespace ProjectManager.Core.Contracts
{
    /// <summary>
    /// Engine that starts application
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Setter and getter for reader propery
        /// </summary>
        IReader Reader { get; set; }

        /// <summary>
        /// Setter and getter for writer propery
        /// </summary>
        IWriter Writer { get; set; }

        /// <summary>
        /// Method that starts the hole application
        /// </summary>
        void Start();
    }
}
