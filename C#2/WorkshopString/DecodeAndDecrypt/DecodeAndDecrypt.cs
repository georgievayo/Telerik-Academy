using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeAndDecrypt
{
    class DecodeAndDecrypt
    {
        static int GetCodeOfLetter(char letter)
        {
            return (int)letter - 65;
        }

        static int GetLengthOfCypher(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; --i)
            {
                if (char.IsDigit(input[i]))
                {
                    sb.Append(input[i]);
                }
                else
                {
                    break;
                }
            }
            string number = string.Empty;
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                number += sb[i];
            }
            int count = int.Parse(number);
            return count;
        }

        static int GetLengthOfSequence(int start, string input)
        {
            string count = string.Empty;
            while (char.IsDigit(input[start]))
            {
                count += input[start];
                start++;
            }
            return int.Parse(count);
        }

        static string ConvertMessage(string input)
        {

            string message = string.Empty;
            if (GetLengthOfCypher(input) < 10)
            {
                input = input.Remove(input.Length - 1);
            }
            else if (GetLengthOfCypher(input) > 9 && GetLengthOfCypher(input) < 100)
            {
                input = input.Remove(input.Length - 2);
            }
            else if (GetLengthOfCypher(input) > 99)
            {
                input = input.Remove(input.Length - 3);
            }


            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    if (GetLengthOfSequence(i, input) < 10)
                    {
                        message += new string(input[i + 1], GetLengthOfSequence(i, input));
                        i++;
                    }
                    else if (GetLengthOfSequence(i, input) > 9 && GetLengthOfSequence(i, input) < 100)
                    {
                        message += new string(input[i + 2], GetLengthOfSequence(i, input));
                        i+= 2;
                    }
                    else if (GetLengthOfSequence(i, input) > 99)
                    {
                        message += new string(input[i + 3], GetLengthOfSequence(i, input));
                        i += 3;
                    }
                    
                }
                else if (!char.IsDigit(input[i]))
                {
                    message += input[i];
                }
            }
            return message;
        }

        static string GetCypher(string input, int length)
        {
            return input.Substring(input.Length - length);
        }

        static string GetMessage(string input, int length)
        {
            return input.Substring(0, input.Length - length);
        }
        static string Encrypt(string message, string cypher)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            if (message.Length > cypher.Length)
            {
                int i = 0;
                    while (i < message.Length)
                    {
                        int result = (GetCodeOfLetter(message[i]) ^ GetCodeOfLetter(cypher[i % cypher.Length])) + (int)'A';
                        encryptedMessage.Append((char)result);
                        i++;
                    }
            }
            else if (message.Length == cypher.Length)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    int result = (GetCodeOfLetter(message[i]) ^ GetCodeOfLetter(cypher[i])) + (int)'A';
                    encryptedMessage.Append((char)result);

                }
            }
            else if(message.Length < cypher.Length)
            {
                int i = 0;
                while (i <= message.Length - 1)
                {
                    int result = 0;
                    if (i + message.Length < cypher.Length)
                    {
                        result = (GetCodeOfLetter((char)((GetCodeOfLetter(message[i]) ^ GetCodeOfLetter(cypher[i])) + (int)'A')) ^ GetCodeOfLetter(cypher[i + message.Length])) + (int)'A';
                    }
                    else
                    {
                        result = (GetCodeOfLetter(message[i]) ^ GetCodeOfLetter(cypher[i])) + (int)'A';
                    }
                    encryptedMessage.Append((char)result);
                    i++;
                }
            }

            return encryptedMessage.ToString();
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int lengthOfCypher = GetLengthOfCypher(input);
            //Console.WriteLine(lengthOfCypher);
            string convertedInput = ConvertMessage(input);
            //Console.WriteLine(convertedInput);

            //Console.WriteLine("cypher= {0}", GetCypher(convertedInput, lengthOfCypher));
            //Console.WriteLine("message = {0}", GetMessage(convertedInput, lengthOfCypher));
            Console.WriteLine(Encrypt(GetMessage(convertedInput, lengthOfCypher), GetCypher(convertedInput, lengthOfCypher)));
            //Console.WriteLine(Encrypt("ABC","PQRST"));
        }
    }
}
