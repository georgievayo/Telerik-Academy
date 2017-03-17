using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class Student : IStudent
    {
        private int id;
        private string name;

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                if(value >= 10000 && value < 99999)
                {
                    this.id = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
           set
            {
                if(value.Length > 0)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Student()
        {

        }

        public Student(int id, string name)
        {
            this.Name = name;
            this.ID = id;
        }
    }
}
