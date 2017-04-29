using System;
using System.Collections.Generic;
using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        // TODO: Implement this

        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute(IList<string> parameters)
        {
            StringBuilder result = new StringBuilder();
            foreach (var trainer in this.engine.Trainers)
            {
                result.AppendLine(trainer.ToString());
            }
            foreach (var student in this.engine.Students)
            {
                result.Append(student);
            }
            return result.ToString();
        }
    }
}
