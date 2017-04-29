using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils;
using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        private static IAcademyFactory instanceHolder = new AcademyFactory();

        // private because of Singleton design pattern
        private AcademyFactory()
        {
        }

        public static IAcademyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            // TODO: Implement this
            return new Student(username, track);
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {
            // TODO: Implement this
            string[] techn = technologies.Split(','); 
            return new Trainer(username, techn);
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {
            // TODO: Implement this
            return new Course(name, lecturesPerWeek, startingDate);
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {
            // TODO: Implement this
            return new Lecture(name, date, trainer);
        }

        public ILectureResouce CreateLectureResouce(string type, string name, string url)
        {
            // Use this instead of DateTime.Now if you want any points in BGCoder!!
            var currentDate = DateTimeProvider.Now;

            switch (type)
            {
                case "video": return new VideoResource(currentDate, name, url);
                case "presentation": return new PresentationResource(name, url);
                case "demo": return new DemoResource(name, url);
                case "homework": return new HomeworkResource(currentDate.AddDays(7), name, url);
                default: throw new ArgumentException("Invalid lecture resource type");
            }
            // TODO: Implement this
          
        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            // TODO: Implement this
            return new CourseResult(course, examPoints, coursePoints);
        }
    }
}
