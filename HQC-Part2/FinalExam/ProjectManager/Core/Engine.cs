using Bytes2you.Validation;
using ProjectManager.Common;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Data;
using ProjectManager.Models;
using System;
using System.Text;
using ProjectManager.Common.Contracts;
using ProjectManager.Core.Contracts;

namespace ProjectManager.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "exit";
        private IFileLogger logger;
        private ICommandProcessor processor;

        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }

        public Engine(IFileLogger logger, ICommandProcessor processor, IWriter writer, IReader reader)
        {
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();

            this.logger = logger;
            this.processor = processor;
            this.Writer = writer;
            this.Reader = reader;
        }

        public void Start()
        {
            while (true)
            {
                var command = this.Reader.ReadLine();

                if (command.ToLower() == TerminationCommand)
                {
                    this.Writer.WriteLine("Program terminated.");
                    this.logger.Info("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.Process(command);
                    this.Writer.WriteLine(executionResult);
                    this.logger.Info(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.Writer.WriteLine(ex.Message);
                    this.logger.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine("Opps, something happened. :(");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
