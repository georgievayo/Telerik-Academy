using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using System.IO;
using System.Reflection;
using Ninject.Extensions.Interception.Infrastructure.Language;
using SchoolSystem.Cli.Interception;
using SchoolSystem.Data;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Factory;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {

            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReaderProvider>();
            this.Bind<IWriter>().To<ConsoleWriterProvider>();
            this.Bind<IParser>().To<CommandParserProvider>();
            this.Bind<IServiceLocator>().To<ServiceLocator>();
            this.Bind<IGenerator>().To<IdGenerator>();
            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>();

            // Commands
            this.Bind<ICommand>().To<CreateStudentCommand>().Named("CreateStudent");
            this.Bind<ICommand>().To<CreateTeacherCommand>().Named("CreateTeacher");
            this.Bind<ICommand>().To<RemoveStudentCommand>().Named("RemoveStudent");
            this.Bind<ICommand>().To<RemoveTeacherCommand>().Named("RemoveTeacher");
            this.Bind<ICommand>().To<StudentListMarksCommand>().Named("StudentListMarks");
            this.Bind<ICommand>().To<TeacherAddMarkCommand>().Named("TeacherAddMark");

            //Models
            this.Bind<IStudent>().To<Student>();
            this.Bind<IMark>().To<Mark>();
            this.Bind<ITeacher>().To<Teacher>();

            var engineBinding = this.Bind<IEngine>().To<Engine>().InSingletonScope();
            var modelsFactoryBinding = this.Bind<IModelsFactory>().ToFactory().InSingletonScope();
            var commandsFactoryBinding = this.Bind<ICommandFactory>().To<CommandFactory>();

            IConfigurationProvider configurationProvider = this.Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                modelsFactoryBinding.Intercept().With<StopwatchInterceptor>();
                commandsFactoryBinding.Intercept().With<StopwatchInterceptor>();
            }
        }
    }
}