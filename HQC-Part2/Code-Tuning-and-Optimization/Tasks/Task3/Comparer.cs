using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Comparer
    {
        static void Main(string[] args)
        {
            var sqrtFloat = CalculateFloatSquareRoot(3.658f);
            var sqrtDouble = CalculateDoubleSquareRoot(3.658);
            var sqrtDecimal = CalculateDecimalSquareRoot(3.658m);

            Console.WriteLine("Square root float: {0}", sqrtFloat);
            Console.WriteLine("Square root double: {0}", sqrtDouble);
            Console.WriteLine("Square root decimal: {0}", sqrtDecimal);
            Console.WriteLine();

            var logFloat = CalculateFloatLogarithm(3.658f);
            var logDouble = CalculateDoubleLogarithm(3.658);
            var logDecimal = CalculateDecimalLogarithm(3.658m);

            Console.WriteLine("Natural logarithm float: {0}", sqrtFloat);
            Console.WriteLine("Natural logarithm double: {0}", sqrtDouble);
            Console.WriteLine("Natural logarithm decimal: {0}", sqrtDecimal);
            Console.WriteLine();

            var sinFloat = CalculateFloatSinus(3.658f);
            var sinDouble = CalculateDoubleSinus(3.658);
            var sinDecimal = CalculateDecimalSinus(3.658m);

            Console.WriteLine("Sinus float: {0}", sqrtFloat);
            Console.WriteLine("Sinus double: {0}", sqrtDouble);
            Console.WriteLine("Sinus decimal: {0}", sqrtDecimal);
        }

        #region SquareRoot

        static TimeSpan CalculateFloatSquareRoot(float number)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = Math.Sqrt(number);
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateDoubleSquareRoot(double number)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = Math.Sqrt(number);
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateDecimalSquareRoot(decimal number)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = Math.Sqrt((double)number);
            sw.Stop();
            return sw.Elapsed;
        }
        #endregion

        #region NaturalLogarith
        static TimeSpan CalculateFloatLogarithm(float number)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = Math.Log(number);
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateDoubleLogarithm(double number)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = Math.Log(number);
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateDecimalLogarithm(decimal number)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = Math.Log((double)number);
            sw.Stop();
            return sw.Elapsed;
        }
        #endregion

        #region Sinus
        static TimeSpan CalculateFloatSinus(float number)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = Math.Sin(number);
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateDoubleSinus(double number)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = Math.Sin(number);
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateDecimalSinus(decimal number)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = Math.Sin((double)number);
            sw.Stop();
            return sw.Elapsed;
        }
        #endregion
    }
}
