using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolSystem.Models;

namespace SchoolSystem.Core
{
    public class Engine
    {
        private IReader reader;

        public Engine(IReader reader)
        {
            this.reader = reader;
            Teachers = new Dictionary<int, ITeacher>();
            Students = new Dictionary<int, IStudent>();
        }

        internal static Dictionary<int, ITeacher> Teachers { get; set; }

        internal static Dictionary<int, IStudent> Students { get; set; }

        public void Start()
        {
            var command = this.GetCommand();
            while (command != "End")
            {
                try
                {
                    var commandName = command.Split(' ')[0];
                    var assembly = GetType().GetTypeInfo().Assembly;
                    var foundCommand = assembly.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                        .FirstOrDefault();
                    if (foundCommand == null)
                    {
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var commandObj = Activator.CreateInstance(foundCommand) as ICommand;
                    var paramsOfCommand = command.Split(' ').ToList();
                    paramsOfCommand.RemoveAt(0);
                    this.WriteLine(commandObj.Execute(paramsOfCommand));
                }
                catch (ArgumentException ex)
                {
                    this.WriteLine(ex.Message);
                }

                command = this.GetCommand();
            }
        }

        private string GetCommand()
        {
            var command = this.reader.ReadLine();
            return command;
        }

        private void WriteLine(string text)
        {
            Console.Write(text);
            Console.WriteLine();
            //Thread.Sleep(350);
        }
    }
}
