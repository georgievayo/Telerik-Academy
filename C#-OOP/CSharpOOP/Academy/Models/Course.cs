using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Course : ICourse
    {
        private const int minLecturesPerWeek = 1;
        private const int maxLecturesPerWeek = 7;
        private const int minLengthOfName = 3;
        private const int maxLengthOfName = 45;

        private string name;
        private int lecturesPerWeek;
        private DateTime endingDate;
        private List<ILecture> lectures;
        private List<IStudent> onlineStudents;
        private List<IStudent> onsiteStudents;
        private DateTime startingDate;

        public Course(string name, string lecturesPerWeek, string startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = int.Parse(lecturesPerWeek);
            this.StartingDate = DateTime.Parse(startingDate);
            this.EndingDate = this.StartingDate.AddDays(30);
            this.lectures = new List<ILecture>();
            this.onlineStudents = new List<IStudent>();
            this.onsiteStudents = new List<IStudent>();
        }

        public DateTime EndingDate
        {
            get
            {
                return this.endingDate;
            }

            set
            {
                this.endingDate = value;
            }
        }

        public IList<ILecture> Lectures
        {
            get
            {
                return this.lectures;
            }
        }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }

            set
            {
                if (value > minLecturesPerWeek && value < maxLecturesPerWeek)
                {
                    this.lecturesPerWeek = value;
                }
                else
                {
                    throw new Exception($"The number of lectures per week must be between {minLecturesPerWeek} and {maxLecturesPerWeek}!");
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
                if (value.Length > minLengthOfName && value.Length < maxLengthOfName)
                {
                    this.name = value;
                }
                else
                {
                    throw new Exception($"The name of the course must be between {minLengthOfName} and {maxLengthOfName} symbols!");
                }
            }
        }

        public IList<IStudent> OnlineStudents
        {
            get
            {
                return this.onlineStudents;
            }
        }

        public IList<IStudent> OnsiteStudents
        {
            get
            {
                return this.onsiteStudents;
            }
        }

        public DateTime StartingDate
        {
            get
            {
                return this.startingDate;
            }

            set
            {
                this.startingDate = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("* Course:");
            result.AppendLine($" - Name: {this.Name}");
            result.AppendLine($" - Lectures per week: {this.LecturesPerWeek}");
            result.AppendLine($" - Starting date: {this.StartingDate.ToString("yyyy-MM-dd hh:mm:ss tt")}");
            result.AppendLine($" - Ending date: {this.EndingDate.ToString("yyyy-MM-dd hh:mm:ss tt")}");
            result.AppendLine($" - Onsite students: {this.onsiteStudents.Count}");
            result.AppendLine($" - Online students: {this.onlineStudents.Count}");
            result.AppendLine($" - Lectures:");
            if (this.lectures.Count > 0)
            {
                foreach (var lecture in this.lectures)
                {
                    result.Append(lecture.ToString());
                }
            }
            else
            {
                result.AppendLine("  * There are no lectures in this course!");
            }
            return result.ToString();
        }
    }
}
