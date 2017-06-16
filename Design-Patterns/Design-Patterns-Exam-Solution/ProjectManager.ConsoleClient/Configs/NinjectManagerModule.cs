using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using ProjectManager.ConsoleClient.Configs;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Data;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Decorators;
using ProjectManager.Framework.Core.Commands.Listing;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Services;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope().Intercept().With<LogErrorInterceptor>();

            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                    .SelectAllClasses()
                    .Where(type => type != typeof(Engine) && type != typeof(Database) && type != typeof(CachingService))
                    .BindDefaultInterface();
            });

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();

            // Commands bindings
            this.Bind<ICommand>().To<CreateProjectCommand>().InSingletonScope().Named("CreateProject");
            this.Bind<ICommand>().To<CreateTaskCommand>().InSingletonScope().Named("CreateTask");
            this.Bind<ICommand>().To<CreateUserCommand>().InSingletonScope().Named("CreateUser");
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().InSingletonScope().Named("ListProjectDetails");
            this.Bind<ICommand>().To<ListProjectsCommand>().InSingletonScope().Named("ListProjects");


            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();

            this.Bind<ILogger>()
                .To<FileLogger>()
                .InSingletonScope()
                .WithConstructorArgument(configurationProvider.LogFilePath);

            this.Bind<ICachingService>()
                .To<CachingService>()
                .InSingletonScope()
                .WithConstructorArgument(configurationProvider.CacheDurationInSeconds);
        }
    }
}
