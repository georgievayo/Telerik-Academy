using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Interception;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Cli.Interception
{
    public class StopwatchInterceptor : IInterceptor
    {
        private readonly Stopwatch timer;
        private readonly IWriter writer;

        public StopwatchInterceptor(IWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("Writer cannot be null.");
            }

            this.writer = writer;
            this.timer = new Stopwatch();
        }
        public void Intercept(IInvocation invocation)
        {
            this.writer.WriteLine($"Calling method {invocation.Request.Method.Name} of type {invocation.Request.Method}...");

            this.timer.Start();
            invocation.Proceed();
            this.timer.Stop();

            this.writer.WriteLine("Print again");
        }
    }
}
