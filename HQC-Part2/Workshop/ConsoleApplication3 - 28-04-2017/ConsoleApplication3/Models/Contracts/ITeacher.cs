using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    public interface ITeacher : IPerson
    {
        Subject Subject
        {
            get;
            set;
        }

        void WriteMarkTo(IStudent student, IMark mark);
    }
}
