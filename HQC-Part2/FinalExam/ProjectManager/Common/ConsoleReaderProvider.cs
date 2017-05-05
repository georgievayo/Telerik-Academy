using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Common.Contracts;

namespace ProjectManager.Common
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
