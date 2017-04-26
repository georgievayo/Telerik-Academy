using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Comparer
    {
        static void Main(string[] args)
        {
            var addIntegersTime = CalculateAddIntegersTime(8, 3);
            var addLongsTime = CalculateAddLongsTime(9223372036854775, 9223372036854775);
            var addDoublesTime = CalculateAddDoublesTime(2.5897856, 8.546262);
            var addFloatsTime = CalculateAddFloatsTime(2.66656f, 3.587952f);
            var addDecimalsTime = CalculateAddDecimalsTime(5.898956m, 8.1546m);

            Console.WriteLine("int + int: {0}", addIntegersTime);
            Console.WriteLine("long + long: {0}", addLongsTime);
            Console.WriteLine("double + double: {0}", addDoublesTime);
            Console.WriteLine("float + float: {0}", addFloatsTime);
            Console.WriteLine("decimal + decimal: {0}", addDecimalsTime);
            Console.WriteLine();

            var incrementIntegersTime = CalculateIncrementIntegerTime(8);
            var incrementLongsTime = CalculateIncrementLongTime(922337203);
            var incrementDoublesTime = CalculateIncrementDoubleTime(2.5897856);
            var incrementFloatsTime = CalculateIncrementFloatTime(2.66656f);
            var incrementDecimalsTime = CalculateIncrementDecimalTime(5.898956m);

            Console.WriteLine("int++: {0}", incrementIntegersTime);
            Console.WriteLine("long++: {0}", incrementLongsTime);
            Console.WriteLine("double++: {0}", incrementDoublesTime);
            Console.WriteLine("float++: {0}", incrementFloatsTime);
            Console.WriteLine("decimal++: {0}", incrementDecimalsTime);
            Console.WriteLine();

            var subtractIntegersTime = CalculateSubtractIntegersTime(8, 3);
            var subtractLongsTime = CalculateSubtractLongsTime(9223372036854775, 9223372036854775);
            var subtractDoublesTime = CalculateSubtractDoublesTime(2.5897856, 8.546262);
            var subtractFloatsTime = CalculateSubtractFloatsTime(2.66656f, 3.587952f);
            var subtractDecimalsTime = CalculateSubtractDecimalsTime(5.898956m, 8.1546m);

            Console.WriteLine("int - int: {0}", addIntegersTime);
            Console.WriteLine("long - long: {0}", addLongsTime);
            Console.WriteLine("double - double: {0}", addDoublesTime);
            Console.WriteLine("float - float: {0}", addFloatsTime);
            Console.WriteLine("decimal - decimal: {0}", addDecimalsTime);
            Console.WriteLine();

            var multiplyIntegersTime = CalculateMultiplyIntegersTime(8, 3);
            var multiplyLongsTime = CalculateMultiplyLongsTime(9223372036854775, 9223372036854775);
            var multiplyDoublesTime = CalculateMultiplyDoublesTime(2.5897856, 8.546262);
            var multiplyFloatsTime = CalculateMultiplyFloatsTime(2.66656f, 3.587952f);
            var multiplyDecimalsTime = CalculateMultiplyDecimalsTime(5.898956m, 8.1546m);

            Console.WriteLine("int * int: {0}", multiplyIntegersTime);
            Console.WriteLine("long * long: {0}", multiplyLongsTime);
            Console.WriteLine("double * double: {0}", multiplyDoublesTime);
            Console.WriteLine("float * float: {0}", multiplyFloatsTime);
            Console.WriteLine("decimal * decimal: {0}", multiplyDecimalsTime);
            Console.WriteLine();

            var divideIntegersTime = CalculateDivideIntegersTime(8, 3);
            var divideLongsTime = CalculateDivideLongsTime(9223372036854775, 9223372036854775);
            var divideDoublesTime = CalculateDivideDoublesTime(2.5897856, 8.546262);
            var divideFloatsTime = CalculateDivideFloatsTime(2.66656f, 3.587952f);
            var divideDecimalsTime = CalculateDivideDecimalsTime(5.898956m, 8.1546m);

            Console.WriteLine("int / int: {0}", divideIntegersTime);
            Console.WriteLine("long / long: {0}", divideLongsTime);
            Console.WriteLine("double / double: {0}", divideDoublesTime);
            Console.WriteLine("float / float: {0}", divideFloatsTime);
            Console.WriteLine("decimal / decimal: {0}", divideDecimalsTime);
            Console.WriteLine();



        }

        #region Add
        static TimeSpan CalculateAddIntegersTime(int firstNumber, int secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            int result = 0;
            sw.Start();      
            result = firstNumber + secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateAddLongsTime(long firstNumber, long secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            long result = 0;
            sw.Start();
            result = firstNumber + secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateAddDoublesTime(double firstNumber, double secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = firstNumber + secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateAddFloatsTime(float firstNumber, float secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            float result = 0;
            sw.Start();
            result = firstNumber + secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateAddDecimalsTime(decimal firstNumber, decimal secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            decimal result = 0;
            sw.Start();
            result = firstNumber + secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }
        #endregion

        #region Increment
        static TimeSpan CalculateIncrementIntegerTime(int number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            number++;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateIncrementLongTime(long number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            number++;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateIncrementDoubleTime(double number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            number++;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateIncrementFloatTime(float number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            number++;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateIncrementDecimalTime(decimal number)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            number++;
            sw.Stop();
            return sw.Elapsed;
        }
        #endregion

        #region Multiply
        static TimeSpan CalculateMultiplyIntegersTime(int firstNumber, int secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            int result = 0;
            sw.Start();
            result = firstNumber * secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateMultiplyLongsTime(long firstNumber, long secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            long result = 0;
            sw.Start();
            result = firstNumber * secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateMultiplyDoublesTime(double firstNumber, double secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = firstNumber * secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateMultiplyFloatsTime(float firstNumber, float secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            float result = 0;
            sw.Start();
            result = firstNumber * secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateMultiplyDecimalsTime(decimal firstNumber, decimal secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            decimal result = 0;
            sw.Start();
            result = firstNumber * secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }
        #endregion

        #region Divide
        static TimeSpan CalculateDivideIntegersTime(int firstNumber, int secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            int result = 0;
            sw.Start();
            result = firstNumber / secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateDivideLongsTime(long firstNumber, long secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            long result = 0;
            sw.Start();
            result = firstNumber / secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateDivideDoublesTime(double firstNumber, double secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = firstNumber / secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateDivideFloatsTime(float firstNumber, float secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            float result = 0;
            sw.Start();
            result = firstNumber / secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateDivideDecimalsTime(decimal firstNumber, decimal secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            decimal result = 0;
            sw.Start();
            result = firstNumber / secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }
        #endregion

        #region Subtract
        static TimeSpan CalculateSubtractIntegersTime(int firstNumber, int secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            int result = 0;
            sw.Start();
            result = firstNumber - secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateSubtractLongsTime(long firstNumber, long secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            long result = 0;
            sw.Start();
            result = firstNumber - secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateSubtractDoublesTime(double firstNumber, double secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            double result = 0;
            sw.Start();
            result = firstNumber - secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateSubtractFloatsTime(float firstNumber, float secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            float result = 0;
            sw.Start();
            result = firstNumber - secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }

        static TimeSpan CalculateSubtractDecimalsTime(decimal firstNumber, decimal secondNumber)
        {
            Stopwatch sw = new Stopwatch();
            decimal result = 0;
            sw.Start();
            result = firstNumber - secondNumber;
            sw.Stop();
            return sw.Elapsed;
        }
        #endregion
    }
}
