using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupLib;

namespace StudentLib
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private string fn;
        private string tel;
        private string email;
        private List<int> marks;
        private Group group;

        public string FirstName { get { return this.firstName; } private set { this.firstName = value; } }
        public string LastName { get { return this.lastName; } private set { this.lastName = value; } }
        public int Age { get { return this.age; } private set { this.age = value; } }
        public string FN { get { return this.fn; } private set { this.fn = value; } }
        public string Tel { get { return this.tel; } private set { this.tel = value; } }
        public string Email { get { return this.email; } private set { this.email = value; } }
        public List<int> Marks { get { return this.marks; } private set { this.marks = value; } }
        public Group MyGroup { get { return this.group; } private set { this.group = value; } }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Student(string firstName, string lastName, int age): this(firstName, lastName)
        {
            this.Age = age;
        }

        public Student(string firstName, string lastName, string fn, string tel, string email, List<int> marks): this(firstName, lastName)
        {
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.Marks = new List<int>();
            this.Marks = marks;
        }

        public Student(string firstName, string lastName, string fn, string tel, string email, List<int> marks, Group group) : this(firstName, lastName, fn, tel, email, marks)
        {
            this.MyGroup = group;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
