using System;

class PrintADeck
{
     static void Main()
    {

        /*char card = char.Parse(Console.ReadLine());
        char[] deck = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'A', 'J', 'Q', 'K' };
        for(int i = 0; i <= Array.IndexOf(deck, card); i++)
        {
            Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds ", deck[i]);
        }*/

        string card = Console.ReadLine();
        string[] deck = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        for (int i = 0; i <= Array.IndexOf(deck, card); i++)
        {
            Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds ", deck[i]);
        }
    }
}