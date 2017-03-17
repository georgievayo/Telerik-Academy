using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class TestMatrix
    {
        static void Main(string[] args)
        {
            Matrix2D<int> myMatrix = new Matrix2D<int>(3,3);
            Console.WriteLine("First matrix:");
            for (int i = 0; i < myMatrix.Rows; i++)
            {
                for (int j = 0; j < myMatrix.Cols; j++)
                {
                    myMatrix[i, j] = j - i + 5;
                    Console.Write("{0} ", myMatrix[i,j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Second matrix:");
            Matrix2D<int> otherMatrix = new Matrix2D<int>(3, 3);
            for (int i = 0; i < otherMatrix.Rows; i++)
            {
                for (int j = 0; j < otherMatrix.Cols; j++)
                {
                    otherMatrix[i, j] = 2*j + 3*i;
                    Console.Write("{0} ", otherMatrix[i, j]);
                }
                Console.WriteLine();
            }

            Matrix2D<int> sum = myMatrix + otherMatrix;
            Console.WriteLine("The sum is:");
            for (int i = 0; i < sum.Rows; i++)
            {
                for (int j = 0; j < sum.Cols; j++)
                {
                    Console.Write("{0} ", sum[i,j]);
                }
                Console.WriteLine();
            }

            Matrix2D<int> subtraction = myMatrix - otherMatrix;
            Console.WriteLine("The subtraction is:");
            for (int i = 0; i < subtraction.Rows; i++)
            {
                for (int j = 0; j < subtraction.Cols; j++)
                {
                    Console.Write("{0} ", subtraction[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("The product is:");
            Matrix2D<int> product = myMatrix * otherMatrix;
            for (int i = 0; i < product.Rows; i++)
            {
                for (int j = 0; j < product.Cols; j++)
                {
                    Console.Write("{0} ", product[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
