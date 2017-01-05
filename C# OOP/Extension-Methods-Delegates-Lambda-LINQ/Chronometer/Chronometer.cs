using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronometer
{
    class Chronometer
    {
        static void Main(string[] args)
        {
            Timer myTimer = new Timer(3);
            myTimer.Invoke();
        }
    }
}
