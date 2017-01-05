using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class TestList
    {
        static void Main(string[] args)
        {
            GenericList<int> myList = new GenericList<int>(5);
            myList.Add(15);
            myList.Add(5);
            myList.Add(100);
            myList.Add(3);
            myList.Add(19);
            myList.Add(-14);

            Console.WriteLine(myList);
            Console.WriteLine("Element on index 2 is: {0}", myList[2]);
            Console.WriteLine("Element 19 is on position: {0}", myList.IndexOf(19));
            myList.DeleteAt(0);
            Console.WriteLine(myList);
            myList.InsertAt(200,0);
            Console.WriteLine(myList);
            Console.WriteLine("Max element: {0}", myList.Max());
            Console.WriteLine("Min element: {0}", myList.Min());

            myList.Clear();
            Console.WriteLine("Number of elements after clearing is: {0}", myList.Count);

        }
    }
}
