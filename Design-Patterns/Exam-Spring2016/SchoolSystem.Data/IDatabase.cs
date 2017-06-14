using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Data
{
    public interface IDatabase
    {
        IDictionary<int, ITeacher> Teachers { get; set; }

        IDictionary<int, IStudent> Students { get; set; }
    }
}
