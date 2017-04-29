using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using SchoolSystem.Models;

namespace SchoolSystem
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReaderProvider();
            var service = new BusinessLogicService();
            service.Execute(reader);
        }
    }
}
