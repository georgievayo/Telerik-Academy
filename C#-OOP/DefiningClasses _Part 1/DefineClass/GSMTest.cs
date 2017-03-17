using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClass
{
    public class GSMTest
    {
        public static void Test()
        { 
            List <GSM> myList = new List<GSM>();
            myList.Add(new GSM("Samsung", "Samsung", 549.90, "Gosho", new Battery("SamsungBat", 15,21,BatteryType.LiIon), new Display(4.7, 5000)));
            myList.Add(new GSM("Nokia", "Nokia", 99, "Pencho", new Battery("NokiaBat", 18, 25, BatteryType.NiMH), new Display(2.7, 1000)));
            myList.Add(new GSM("LG", "LG", 1020, "Misho", new Battery("LGBat", 20, 28, BatteryType.LiIon), new Display(4.5, 8000)));
            myList.Add(new GSM("Lenovo", "Lenovo", 420, "Pesho", new Battery("LenovoBat", 13, 18, BatteryType.NiCd), new Display(5.1, 10000)));
            myList.Add(GSM.Iphone4S);

            foreach (var gsm in myList)
            {
                Console.WriteLine(gsm);
                Console.WriteLine();
            }
            
        }
    }
}
