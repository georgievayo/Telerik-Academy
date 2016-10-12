using System;

class IntDoubleString
{
    static void Main()
    {
        string command = Console.ReadLine();
        if (command == "integer")
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(number + 1);
        }
        else if (command == "real")
        {
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F2}",number + 1);
        }
        else if (command == "text")
        {
            string text = Console.ReadLine();
            Console.WriteLine(text + "*");
        }
    }
}

