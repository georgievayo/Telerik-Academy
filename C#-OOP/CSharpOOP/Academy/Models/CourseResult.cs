using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;
using Academy.Models.Enums;

namespace Academy.Models
{
    public class CourseResult : ICourseResult
    {
        private const float minExamPoints = 0;
        private const float maxExamPoints = 1000;
        private const float minCoursePoints = 0;
        private const float maxCoursePoints = 125;

        private readonly ICourse course;
        private readonly float coursePoints;
        private readonly float examPoints;
        private readonly Grade grade;

        public CourseResult(ICourse course, string examPoints, string coursePoints)
        {
            this.course = course;
            float ePoints = float.Parse(examPoints);
            if (ePoints > minExamPoints && ePoints < maxExamPoints)
            {
                this.examPoints = ePoints;
            }
            else
            {
                throw new Exception($"Course result's exam points should be between {minExamPoints} and {maxExamPoints}!");
            }
            float cPoints = float.Parse(coursePoints);
            if (cPoints > minCoursePoints && cPoints < maxCoursePoints)
            {
                this.coursePoints = cPoints;
            }
            else
            {
                throw new Exception($"Course result's course points should be between {minCoursePoints} and {maxCoursePoints}!");
            }

            //Calculate grade
            if (this.examPoints >= 65 || this.coursePoints >= 75)
            {
                this.grade = Grade.Excellent;
            }
            else if ((this.examPoints < 60 && this.examPoints >= 30) || (this.coursePoints < 75 && this.coursePoints >= 45))
            {
                this.grade = Grade.Passed;
            }
            else
            {
                this.grade = Grade.Failed;
            }
        }

        public ICourse Course
        {
            get
            {
                return this.course;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($@"   * {this.Course.Name}: Points - {this.CoursePoints}, Grade - {this.Grade}");
            return result.ToString();
        }
    }
}
