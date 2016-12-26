using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClass
{
    public class Call
    {
        private string date;
        private string time;
        private string phoneNumber;
        private double duration;
        public const double pricePerMinute = 0.37;
        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Date should be longer than 0");
                }
                this.date = value;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Time should be longer than 0");
                }
                this.time = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Phine number should be longer than 0");
                }
                this.phoneNumber = value;
            }
        }

        public double Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value<= 0)
                {
                    throw new ArgumentException("Duration should be more than 0");
                }
                this.duration = value;
            }
        }

        public Call(string date, string time, string phoneNum, double duration)
        {
            Date = date;
            Time = time;
            PhoneNumber = phoneNum;
            Duration = duration;
        }

    }
}
