using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolSystem.Framework
{
    public class IdGenerator : IGenerator
    {
        private static int id = 1;

        public int GetNext()
        {
            return Interlocked.Increment(ref id);
        }
    }
}
