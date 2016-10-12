using System;

class PlayCard
{
    static void Main()
    {
        string symbol = Console.ReadLine();
        if (symbol == "1" || symbol == "2" || symbol == "3" || symbol == "4" || symbol == "5" || symbol == "6" || symbol == "7" || symbol == "8" || symbol == "9" || symbol == "10" || symbol == "J" || symbol == "K" || symbol == "Q" || symbol == "A")
        {
            Console.WriteLine("yes {0}", symbol);
        }
        else Console.WriteLine("no {0}", symbol);
    }
}

