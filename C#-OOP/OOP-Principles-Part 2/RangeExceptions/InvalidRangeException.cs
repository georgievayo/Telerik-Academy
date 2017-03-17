using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeExceptions
{
    public class InvalidRangeException : ArgumentException
        
    {
        public InvalidRangeException(string message) : base(message)
        {

        }
        public InvalidRangeException(string message, string start, string end)
            : base(message)
        {
            Console.WriteLine("{0} Range must be between {1} and {2}", message, start, end);
        }
        public InvalidRangeException() : base()
        {

        }
        public InvalidRangeException(string message, Exception innerEx) : base(message, innerEx)
        {

        }
    }
}
