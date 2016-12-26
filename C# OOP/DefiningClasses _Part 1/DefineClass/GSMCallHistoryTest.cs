using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClass
{
    public class GSMCallHistoryTest
    {
        public static void CallHistoryTest()
        {
            GSM gsm = new GSM("Samsung", "Samsung", 549.90, "Gosho", new Battery("SamsungBat", 15, 21, BatteryType.LiIon), new Display(4.7, 5000));

            gsm.AddCall(new Call("12.10.2016", "15:48", "0877547511", 133.21));
            gsm.AddCall(new Call("27.10.2016", "15:28", "0877547511", 213));
            gsm.AddCall(new Call("01.12.2016", "05:14", "0877547511", 333.3));

            gsm.DisplayCallHistory();
            Console.WriteLine();
            Console.WriteLine("Total Price: {0}", gsm.CalculateTotalPrice());
            Console.WriteLine();
            //Find call with max duration
            Call max = gsm.CallHistory[0];
            for (int i = 1; i < gsm.CallHistory.Count; i++)
            {
                if (gsm.CallHistory[i].Duration > max.Duration)
                {
                    max = gsm.CallHistory[i];
                }
            }
            gsm.DeleteCall(max);
            Console.WriteLine("Total Price after removing an element: {0}", gsm.CalculateTotalPrice());
            gsm.ClearHistory();
            Console.WriteLine();
            Console.WriteLine("Total Price after clear: {0}", gsm.CalculateTotalPrice());
        }
    }
}
