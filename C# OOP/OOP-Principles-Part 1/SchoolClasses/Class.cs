using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses
{
    public class Class : ICommentable
    {
        public string ID { get; private set; }

        public List<Student> students { get; private set; }

        public List<Teacher> teachers { get; private set; }

        public string Comment { get; set; }

        public Class(string id, List<Student> students, List<Teacher> teachers)
        {
            this.ID = id;
            this.students = students;
            this.teachers = teachers;
        }
    }
}
