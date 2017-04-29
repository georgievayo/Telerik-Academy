using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    public interface IStudent : IPerson
    {
        Grade StudentGrade
        {
            get;
            set;
        }

        ICollection<IMark> Marks
        {
            get;
            set;
        }

        string ListMarks();
    }
}
