using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Lecture : ILecture
    {
        private const int minLengthOfName = 5;
        private const int maxLengthOfName = 30;

        private string name;
        private DateTime date;
        private List<ILectureResouce> resources;
        private ITrainer trainer;

        public Lecture(string name, string date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = DateTime.Parse(date);
            this.Trainer = trainer;
            this.resources = new List<ILectureResouce>();
        }
        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
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
                if (value.Length < minLengthOfName || value.Length > maxLengthOfName)
                {
                    throw new Exception($"Lecture's name should be between {minLengthOfName} and {maxLengthOfName} symbols long!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public IList<ILectureResouce> Resouces
        {
            get
            {
                return this.resources;
            }
        }

        public ITrainer Trainer
        {
            get
            {
                return this.trainer;
            }

            set
            {
                this.trainer = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("  * Lecture:");
            result.AppendLine($@"   - Name: {this.Name}");
            result.AppendLine($@"   - Date: {this.Date.ToString("yyyy-MM-dd hh:mm:ss tt")}");
            result.AppendLine($@"   - Trainer username: {this.Trainer.Username}");
            result.AppendLine(@"   - Resources:");
            if (this.resources.Count > 0)
            {
                foreach (var resource in this.Resouces)
                {
                    result.Append(resource.ToString());
                }
            }
            else
            {
                result.AppendLine(@"    * There are no resources in this lecture.");
            }
            return result.ToString();
        }
    }
}
