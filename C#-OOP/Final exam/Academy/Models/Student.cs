using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Utils.Contracts;

namespace Academy.Models
{
    public class Student : IStudent
    {
        private const int minLengthOfName = 3;
        private const int maxLengthOfName = 16;

        private string username;
        private Track track;
        private IList<ICourseResult> courseResults;

        public Student(string username, string track)
        {
            this.Username = username;
            Track givenTrack;
            switch(track)
            {
                case "Frontend": givenTrack = Track.Frontend; break;
                case "Dev": givenTrack = Track.Dev; break;
                case "None": givenTrack = Track.None; break;
                default: throw new Exception("The provided track is not valid!");
            }
            this.Track = givenTrack;

            this.CourseResults = new List<ICourseResult>();
        }

        public IList<ICourseResult> CourseResults
        {
            get
            {
                return this.courseResults;
            }

            set
            {
                this.courseResults = value;
            }
        }

        public Track Track
        {
            get
            {
                return this.track;
            }

            set
            {
                this.track = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (value.Length > minLengthOfName && value.Length < maxLengthOfName)
                {
                    this.username = value;
                }
                else
                {
                    throw new Exception($"User's username should be between {minLengthOfName} and {maxLengthOfName} symbols long!");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("* Student:");
            result.AppendLine($" - Username: {this.Username}");
            result.AppendLine($" - Track: {this.Track}");
            result.AppendLine(" - Course results:");
            if (this.CourseResults.Count == 0)
            {
                result.AppendLine("  * User has no course results!");
            }
            else
            {
                foreach (var res in this.CourseResults)
                {
                    result.Append($@"  * {res.Course.Name}: Points - {res.CoursePoints}, Grade - {res.Grade}");
                }
            }
            return result.ToString();
        }
    }
}
