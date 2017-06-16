using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Interception;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;

namespace ProjectManager.ConsoleClient.Interceptors
{
    public class LogErrorInterceptor : IInterceptor
    {
        private readonly ILogger logger;
        private readonly IWriter writer;

        public LogErrorInterceptor(ILogger logger, IWriter writer)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("Logger cannot be null.");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("Writer cannot be null.");
            }

            this.logger = logger;
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();

                var executionResult = invocation.ReturnValue;
                this.writer.WriteLine(executionResult);
            }
            catch (UserValidationException ex)
            {
                this.logger.Error(ex.Message);
                this.writer.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
            }
        }
    }
}
