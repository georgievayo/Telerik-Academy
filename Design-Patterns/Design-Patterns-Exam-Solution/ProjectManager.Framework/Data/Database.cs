using System.Collections.Generic;
using System;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Data.Models;

namespace ProjectManager.Data
{
    // You are not allowed to modify this class (not even to remove this comment)
    public class Database : IDatabase
    {
        private readonly IList<Project> projects;

        public Database()
        {
            this.projects = new List<Project>();
        }

        public IList<Project> Projects
        {
            get
            {
                return this.projects;
            }
        }
    }
}
