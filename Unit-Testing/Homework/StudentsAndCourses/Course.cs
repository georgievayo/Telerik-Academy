using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class Course : ICourse
    {
        private ICollection<IStudent> listOfStudents;

        public ICollection<IStudent> ListOfStudents
        {
            get
            {
                return new List<IStudent>(this.listOfStudents);
            }
        }
        public Course()
        {
            this.listOfStudents = new List<IStudent>();
        }

        public void JoinCourse(IStudent student)
        {
            if(this.listOfStudents.Count >= 30)
            {
                throw new ArgumentOutOfRangeException("The course is full");
            }
            this.listOfStudents.Add(student);
        }

        public void LeaveCourse(IStudent student)
        {
            this.listOfStudents.Remove(student);
        }
    }
}
