using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Chronometer
{
    public class Timer
    {
        //private Stopwatch chronometer;
        private delegate void MyDelegate();
        private int period;

        public Timer(int period)
        {
            this.period = period;
        }
        public void Invoke()
        {
            Stopwatch chronometer = new Stopwatch();

            int time = 0;
            var alarm = new MyDelegate(Alarm);
            chronometer.Start();

            while (time < 6)
            {
                
                if (chronometer.Elapsed.Seconds == period)
                {
                    time++;
                    alarm.Invoke();
                    chronometer.Restart();

                }
                else
                {
                    continue;
                }
            }

        }

        public void Alarm()
        {
            
                Console.WriteLine("Ringggg");
        
        }


    }
}
