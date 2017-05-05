using ProjectManager.Models;
using System.Collections.Generic;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Data
{
    // You are not allowed to modify this interface (except to add documentation)
    /// <summary>
    /// Represents a storage for data
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Method that gets all projects
        /// </summary>
        /// <return>Returns all projects in current database</return>
        IList<IProject> Projects { get; }
    }
}
