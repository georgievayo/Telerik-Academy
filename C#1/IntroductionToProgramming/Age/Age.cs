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
            DateTime dateOfBirth = DateTime.ParseExact(Console.ReadLine(),"MM.dd.yyyy",null);
            DateTime today = new DateTime(2016, 3, 3);
            var age = today.Year - dateOfBirth.Year;
            if (today.Month < dateOfBirth.Month || (today.Month == dateOfBirth.Month && today.Day < dateOfBirth.Day))
            {
                --age;
            }
            Console.WriteLine(age);
            Console.WriteLine(age + 10);
         
        }
    }
}
