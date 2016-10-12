using System;

    class StringsAndObjects
    {
        static void Main()
        {
            string var1 = "Hello";
            string var2 = "World";
            object concatenation = var1 + " " + var2;
            string stringConcatenation = (string) concatenation;
            Console.WriteLine(stringConcatenation);
        }
    }

