using System.ComponentModel.DataAnnotations;
using System.Text;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Models
{
    public class Task : ITask
    {
        public Task(string name, IUser owner, string state)
        {
            this.Name = name;
            this.Owner = owner;
            this.State = state;
        }

        [Required(ErrorMessage = "Task Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Task Owner is required")]
        public IUser Owner { get; set; }

        public string State { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("    Name: " + this.Name);
            result.AppendLine("    Owner: " + this.Owner.Username);
            result.Append("    State: " + this.State);

            return result.ToString();
        }
    }
}
