using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public abstract class Resource : ILectureResouce
    {
        protected const int minLengthOfName = 3;
        protected const int maxLengthOfName = 15;
        protected const int minLengthOfUrl = 5;
        protected const int maxLengthOfUrl = 150;

        protected string name;
        protected string url;
        protected ResourceType type;

        public Resource(string name, string url)
        {
            this.Name = name;
            this.Url = url;
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
                    throw new Exception($"Resource name should be between {minLengthOfName} and {maxLengthOfName} symbols long!");
                }
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                if (value.Length > minLengthOfUrl && value.Length < maxLengthOfUrl)
                {
                    this.url = value;
                }
                else
                {
                    throw new Exception($"Resource url should be between {maxLengthOfUrl} and {maxLengthOfUrl} symbols long!");
                }
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("    * Resource: ");
            result.AppendLine($@"     - Name: {this.Name}");
            result.AppendLine($@"     - Url: {this.Url}");
            result.AppendLine($@"     - Type: {this.type}");
            return result.ToString();
        }
    }
}
