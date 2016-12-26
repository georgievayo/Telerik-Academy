using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Messages
{
    class Messages
    {
        public static string[] Digits = { "cad", "xoz", "nop", "cyk", "min", "mar", "kon", "iva", "ogi", "yan" };

        static string Subtrackt(string num1, string num2)
        { 
            BigInteger firstNum = BigInteger.Parse(num1);
            BigInteger secondNum = BigInteger.Parse(num2);
            BigInteger res = firstNum - secondNum;
            return res.ToString();
        }

        static string Sum(string num1, string num2)
        {
            BigInteger firstNum = BigInteger.Parse(num1);
            BigInteger secondNum = BigInteger.Parse(num2);
            BigInteger res = firstNum + secondNum;
            return res.ToString();
        }
        static string Decrypt(string number)
        {
            string decrypted = string.Empty;
            
            for (int i = 0; i < number.Length; i+=3)
            {
                decrypted += (char)(Array.IndexOf(Digits, number.Substring(i, 3))+48);
            }

            return decrypted;
        }

        static string Encrypt(string number)
        {
            string result = string.Empty;
            for (int i = 0; i < number.Length; i++)
            {
                result += Digits[number[i] - '0'];
            }
            return result;
        }
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            char operation = Convert.ToChar(Console.ReadLine());
            string secondNumber = Console.ReadLine();

            if (operation == '-')
            {
                Console.WriteLine(Encrypt(Subtrackt(Decrypt(firstNumber),Decrypt(secondNumber))));
            }
            else
            {
                Console.WriteLine(Encrypt(Sum(Decrypt(firstNumber), Decrypt(secondNumber))));
            }
        }
    }
}
