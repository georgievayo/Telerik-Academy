using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClass
{
    public class GSM
    {
        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> calls;
        public static GSM Iphone4S = new GSM("Iphone 4s", "Apple", 1200, "Pesho", new Battery("AppleBat", 20, 20, BatteryType.LiIon), new Display(6, 2));

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Model's name should be longer than 0");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Manufacturer's name should be longer than 0");
                }
                this.manufacturer = value;
            }
        }

        public double? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value<= 0)
                {
                    throw new ArgumentException("Price should be more than 0");
                }
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Owner's name should be longer than 0");
                }
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.calls;
            }
            set
            {
                this.calls = value;
            }
        }
        public GSM(string model, string manufacturer) : this(model, manufacturer, null, null, null, null)
        { }

        public GSM(string model, string manufacturer, double? price, string owner) : this(model, manufacturer, price, owner, null, null)
        {
            Price = price;
            Owner = owner;
        }

        public GSM(string model, string manufacturer, double? price, string owner, Battery bat, Display disp)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            Owner = owner;
            Battery = bat;
            Display = disp;
            CallHistory = new List<Call>();
        }

        public override string ToString()
        {
            return $"Model: {this.model}" + "\n" + $"Manufacturer: {this.manufacturer}" + "\n" + $"Price: {this.price}" + "\n" + $"Owner: {this.owner}" + "\n" + $"Battery: {this.battery}" + "\n" + $"Display: {this.display}";
        }

        public void AddCall(Call call)
        {
            CallHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            CallHistory.Remove(call);
        }

        public void ClearHistory()
        {
            CallHistory.Clear();
        }

        public double CalculateTotalPrice()
        {
            double sum = 0;
            foreach (var call in CallHistory)
            {
                sum += Call.pricePerMinute * call.Duration;
            }
            return sum;
        }

        public void DisplayCallHistory()
        {
            foreach (var call in CallHistory)
            {
                Console.WriteLine("{0} {1} {2} {3}", call.Date, call.Time, call.PhoneNumber, call.Duration);
            }
        }
    }
}
