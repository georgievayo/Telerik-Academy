using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    
    public class Trainer : ITrainer
    {
        private const int minLengthOfName = 3;
        private const int maxLengthOfName = 16;

        private string username;
        private IList<string> technologies;

        public Trainer(string username, IList<string> technologies)
        {
            this.Username = username;   
            this.Technologies = technologies;
        }

        public IList<string> Technologies
        {
            get
            {
                return this.technologies;
            }

            set
            {
                this.technologies = value;
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
            result.AppendLine("* Trainer:");
            result.AppendLine($" - Username: {this.Username}");
            string technologiesAsString = string.Join("; ", this.Technologies).TrimEnd();
            result.Append($" - Technologies: {technologiesAsString}");
            return result.ToString();
        }
    }
}
