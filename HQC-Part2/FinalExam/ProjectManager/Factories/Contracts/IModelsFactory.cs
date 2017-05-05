using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Models;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Factories.Contracts
{
    /// <summary>
    /// Factory for users, tasks and projects
    /// </summary>
    public interface IModelsFactory
    {
        /// <summary>
        /// Creates and returns new User
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <returns>IUser</returns>
        IUser CreateUser(string username, string email);

        /// <summary>
        /// Creates and returns new Task
        /// </summary>
        /// <param name="name"></param>
        /// <param name="owner"></param>
        /// <param name="state"></param>
        /// <returns>ITask</returns>
        ITask CreateTask(string name, IUser owner, string state);

        /// <summary>
        /// Creates and returns new Project
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startingDate"></param>
        /// <param name="endingDate"></param>
        /// <param name="state"></param>
        /// <returns>IProject</returns>
        IProject CreateProject(string name, string startingDate, string endingDate, string state);
    }
}
