using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class HomeworkResource : Resource, ILectureResouce
    {
        private readonly DateTime dueDate;

        public HomeworkResource(DateTime dueDate, string name, string url) : base(name, url)
        {
            this.dueDate = dueDate;
            this.type = ResourceType.Homework;
        }

        public DateTime DueDate
        {
            get
            { return this.dueDate; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendLine($@"     - Due date: {this.DueDate.ToString("yyyy-MM-dd hh:mm:ss tt")}");
            return result.ToString();
        }
    }
}
