using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age
{
    class Age
    {
        static void Main(string[] args)
        {
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            var today = DateTime.Today;
            Console.WriteLine(Convert.ToString(today));
            Console.WriteLine(Convert.ToString(dateOfBirth));
            /*var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            Console.WriteLine((a - b) / 10000); */
        }
    }
}
