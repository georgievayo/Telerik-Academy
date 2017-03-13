using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make_Чуек
{
    class Factory
    {
        public void CreatePerson(int number)
        {
            Person person = new Person();
            person.Age = number;
            if (number % 2 == 0)
            {
                person.Name = "Batkata";
                person.gender = Gender.Male;
            }
            else
            {
                person.Name = "Maceto";
                person.gender = Gender.Female;
            }
        }
    }
}
