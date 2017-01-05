using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    [Version(1, 2)]
    public class Matrix2D<T>
        where T: struct, IComparable, IConvertible, IFormattable, IEquatable<T>
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public int Rows { get { return this.rows; } private set { this.rows = value; } }
        public int Cols { get { return this.cols; } private set { this.cols = value; } }
        public T[,] Matrix { get { return this.matrix; } private set { this.matrix = value; } }

        public Matrix2D(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[rows, cols];
        }

        public T this[int i, int j]
        {
            get
            {
                return this.matrix[i, j];
            }

            set
            {
                this.matrix[i, j] = value;
            }
        }

        public static Matrix2D<T> operator +(Matrix2D<T> matrix1,Matrix2D<T> matrix2)
        {
            Matrix2D<T> sum = new Matrix2D<T>(matrix1.Rows, matrix1.Cols);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Cols; j++)
                {
                    dynamic firstEl = matrix1.Matrix[i, j];
                    dynamic secondEl = matrix2.Matrix[i, j];
                    sum.Matrix[i, j] = firstEl + secondEl;
                }
            }
            return sum;
        }

        public static Matrix2D<T> operator -(Matrix2D<T> matrix1, Matrix2D<T> matrix2)
        {
            Matrix2D<T> subtraction = new Matrix2D<T>(matrix1.Rows, matrix1.Cols);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Cols; j++)
                {
                    dynamic firstEl = matrix1.Matrix[i, j];
                    dynamic secondEl = matrix2.Matrix[i, j];
                    subtraction.Matrix[i, j] = firstEl - secondEl;
                }
            }
            return subtraction;
        }

        public static Matrix2D<T> operator *(Matrix2D<T> matrix1, Matrix2D<T> matrix2)
        {
            Matrix2D<T> product = new Matrix2D<T>(matrix1.Rows, matrix1.Cols);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Cols; j++)
                {
                    dynamic firstEl = matrix1.Matrix[i, j];
                    dynamic secondEl = matrix2.Matrix[i, j];
                    product.Matrix[i, j] = firstEl * secondEl;
                }
            }
            return product;
        }

        public static bool operator true(Matrix2D<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    dynamic element = matrix[i, j];
                    if (element == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator false(Matrix2D<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    dynamic element = matrix[i, j];
                    if (element == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
