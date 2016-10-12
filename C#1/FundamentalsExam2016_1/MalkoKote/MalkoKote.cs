using System;

class MalkoKote
{
    static void Main(string[] args)
    {
        int s = int.Parse(Console.ReadLine());
        char symbol = char.Parse(Console.ReadLine());
        char[,] kote = new char[s, s - 1];
        for (int i = 2; i <= ((s - 10) / 4) + 2; i++)
        {
            for (int j = 1; j < s; j++)
            {
                kote[j, i] = symbol;
            }
        }
        kote[0, 1] = symbol;
        kote[0, ((s - 10) / 4) + 3] = symbol;
        for (int i = 1; i <= ((s - 10) / 4) + 1; i++)
        {
            kote[i, 1] = symbol;
            kote[i, ((s - 10) / 4) + 3] = symbol;
        }
        for (int i = ((s - 10) / 2) + 3; i <= s - 1; i++)
        {
            for (int j = 1; j <= ((s - 10) / 4) + 3; j++)
            {
                kote[i, j] = symbol;
            }
        }
        for (int i = ((s - 10) / 2) + 3 + ((s - 10) / 4) + 2; i < s - 1; i++)
        {
            kote[i, 0] = symbol;
            kote[i, ((s - 10) / 4) + 4] = symbol;
        }
        kote[s - 1, ((s - 10) / 4) + 4] = symbol;
        kote[s - 1, ((s - 10) / 4) + 5] = symbol;
        kote[s - 1, ((s - 10) / 4) + 6] = symbol;
        kote[s - 2, ((s - 10) / 4) + 6] = symbol;
        for (int i = s - 2; i >= ((s - 10) / 2) + 3 + ((s - 10) / 4) + 1; i--)
        {
            kote[i, ((s - 10) / 4) + 7] = symbol;
        }
        for (int i = ((s - 10) / 4) + 8; i <= ((s - 10) / 2) + 8; i++)
        {
            kote[((s - 10) / 2) + 3 + ((s - 10) / 4) + 1, i] = symbol;
        }
        /*for (int i = 0; i < s; i++)
        {
            for (int j = 0; j < s - 1; j++)
            {
                Console.Write(kote[i, j]);
            }
            Console.WriteLine();
        }*/
        foreach (var item in kote)
        {
            if(item!=' ')
            {
                Console.Write(item);
            }
        }
    }
}
