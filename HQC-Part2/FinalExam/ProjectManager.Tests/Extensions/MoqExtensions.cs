using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Linq.Expressions;

namespace ProjectManager.Tests.Extensions
{
    public static class MoqExtensions
    {
        public static void SetupMany<TSvc, TReturn>(this Mock<TSvc> mock,
            Expression<Func<TSvc, TReturn>> expression,
            params TReturn[] args)
            where TSvc : class
        {
            if (args.Length == 0)
            {
                mock.Setup(expression)
                    .Returns(null);

                return;
            }

            var numCalls = 0;

            mock.Setup(expression)
                .Returns(() => numCalls < args.Length ? args[numCalls] : args[args.Length - 1])
                .Callback(() => numCalls++);
        }
    }
}
