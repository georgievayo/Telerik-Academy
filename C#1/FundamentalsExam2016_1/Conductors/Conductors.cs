using System;
using System.Text;

class Conductors
{
    static void Main()
    {
        int p = int.Parse(Console.ReadLine());

        string pToStr = Convert.ToString(p, 2);
        string zeroes = "";
        for(int i = 1; i <= pToStr.Length; i++)
        {
            zeroes += '0';
        }
        
        
        int m = int.Parse(Console.ReadLine());

        for (int i = 0; i < m; i++)
        {
            uint n = uint.Parse(Console.ReadLine());

            string nToStr = Convert.ToString(n, 2);
            StringBuilder myStr = new StringBuilder(nToStr);
            for(int j = nToStr.Length - 1; j >= pToStr.Length - 1; j--)
            {
                int k = j;
                int t = pToStr.Length - 1;
                bool isEqual = true;
                while(k >= j - pToStr.Length + 1)
                {
                    if (nToStr[k] != pToStr[t])
                    {
                        isEqual = false;
                    }
                    else
                    {
                        t--;
                    }
                    k--;
                }
                if(isEqual == true)
                {
                    myStr.Insert(j - pToStr.Length + 1, zeroes);
                    myStr.Remove(j+1, pToStr.Length);
                    nToStr = myStr.ToString();
                }

            }
            Console.WriteLine(Convert.ToInt32(nToStr,2));
        }

    }
}

