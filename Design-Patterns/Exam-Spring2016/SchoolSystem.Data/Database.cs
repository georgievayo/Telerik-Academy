using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Data
{
    public class Database : IDatabase
    {
        public Database()
        {
            this.Teachers = new Dictionary<int, ITeacher>();
            this.Students = new Dictionary<int, IStudent>();
        }

        public IDictionary<int, ITeacher> Teachers { get; set; }

        public IDictionary<int, IStudent> Students { get; set; }
    }
}
