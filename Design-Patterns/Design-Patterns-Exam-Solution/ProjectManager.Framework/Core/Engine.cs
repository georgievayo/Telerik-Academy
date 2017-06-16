using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Factories;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers;
using System;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ILogger logger;
        private readonly IProcessor processor;

        public Engine(IReader reader, IWriter writer, ILogger logger, IProcessor processor)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("Reader cannot be null.");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("Writer cannot be null.");
            }

            if (logger == null)
            {
                throw new ArgumentNullException("Logger cannot be null.");
            }

            if (processor == null)
            {
                throw new ArgumentNullException("processor cannot be null.");
            }

            this.reader = reader;
            this.writer = writer;
            this.logger = logger;
            this.processor = processor;
        }

        public void Start()
        {
            for (;;)
            {
                var commandLine = this.reader.ReadLine();

                if (commandLine.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                this.processor.ProcessCommand(commandLine);
            }
        }
    }
}
