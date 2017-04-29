using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models;

namespace SchoolSystem
{
    public class Teacher : ITeacher
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 31;
        private const int MaxNumberOfMarks = 20;

        private string firstName;
        private string lastName;
        private Subject subject;

        public Teacher(string firstName, string lastName, Subject subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
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

        public Subject Subject
        {
            get
            {
                return this.subject;
            }

            set
            {
                if (value != Subject.Bulgarian && value != Subject.English && value != Subject.Math &&
                    value != Subject.Programming)
                {
                    throw new ArgumentException("Incorrect subject!");
                }

                this.subject = value;
            }
        }

        public void WriteMarkTo(IStudent student, IMark mark)
        {
            if (student.Marks.Count >= MaxNumberOfMarks)
            {
                throw new ArgumentException($"Student already has {MaxNumberOfMarks} marks!");
            }

            student.Marks.Add(mark);
        }
    }
}
