using ProjectManager.Framework.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Framework.Services;

namespace ProjectManager.Framework.Core.Commands.Decorators
{
    public class CacheableCommand : ICommand
    {
        private readonly ICommand command;
        private readonly ICachingService service;

        public CacheableCommand(ICommand command, ICachingService service)
        {
            if (command == null)
            {
                throw new ArgumentNullException("Command cannot be null.");
            }

            if (service == null)
            {
                throw new ArgumentNullException("Command cannot be null.");
            }

            this.command = command;
            this.service = service;
        }

        public int ParameterCount
        {
            get
            {
                return this.command.ParameterCount;
            }
        }

        public string Execute(IList<string> parameters)
        {
            if (this.service.IsExpired)
            {
                var result = this.command.Execute(parameters);
                this.service.ResetCache();
                this.service.AddCacheValue("ListProjects", "Execute", result);
                return result;
            }
            else
            {
                var result = this.service.GetCacheValue("ListProjects", "Execute");
                return (string)result;
            }
        }
    }
}
