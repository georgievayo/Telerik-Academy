using ProjectManager.Common;
using ProjectManager.Common.Providers;
using ProjectManager.Core;
using ProjectManager.Data;
using ProjectManager.Factories;
using ProjectManager.Models;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            var db = new Database();
            var modelsFactory = new ModelsFactory();
            var logger = new FileLogger();
            var commandsFactory = new CommandsFactory(db, modelsFactory);
            var commandProcessor = new CommandProcessor(commandsFactory);
            var reader = new ConsoleReaderProvider();
            var writer = new ConsoleWriterProvider();

            var engine = new Engine(logger, commandProcessor, writer, reader);
            engine.Start();
        }
    }
}