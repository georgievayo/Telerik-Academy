using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models;

namespace SchoolSystem
{
    public class Student : IStudent
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 31;

        private string firstName;
        private string lastName;
        private Grade grade;
        private ICollection<IMark> marks;

        public Student(string firstName, string lastName, Grade grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StudentGrade = grade;
            this.Marks = new List<IMark>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("First name shouldn't be null!");
                }
                else if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException(
                        $"First name should be consisted of between {MinNameLength} and {MaxNameLength} letters!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Last name shouldn't be null!");
                }
                else if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException(
                        $"Last name should be consisted of between {MinNameLength} and {MaxNameLength} letters!");
                }

                this.lastName = value;
            }
        }

        public Grade StudentGrade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if ((int)value < 1 || (int)value > 12)
                {
                    throw new ArgumentException("Grade of student should be between 1 and 12!");
                }

                this.grade = value;
            }
        }

        public ICollection<IMark> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Marks of student shouldn't be null!");
                }

                this.marks = value;
            }
        }

        public string ListMarks()
        {
            var result = new StringBuilder();
            foreach (var mark in this.marks)
            {
                result.AppendLine($"{mark.Subject} => {mark.Value}");
            }

            return result.ToString();
        }
    }
}
