using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericList<T>
        where T : IComparable
    {
        private T[] array;
        private int lastIndex;
        private int capacity;

        public T[] Array { get { return this.array; } private set { this.array = value; } }

        public int Capacity { get; private set; }

        public int Count { get { return this.lastIndex + 1; } private set { } }

        public GenericList(int capacity)
        {
            this.capacity = capacity;
            this.array = new T[capacity];
            this.lastIndex = -1;
        }

        public void Add(T element)
        {
            if (this.lastIndex >= this.capacity - 1)
            {
                Expand();
            }
            this.lastIndex++;
            this.array[this.lastIndex] = element;
        }

        public T this[int index]
        {
            get
            {
                if (index > -1 && index < this.Count)
                {
                    return this.array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }


        public void DeleteAt(int position)
        {
            if (position > -1 && position < this.Count)
            {
                for (int i = position; i < this.Count; i++)
                {
                    this.array[i] = this.array[i + 1];
                }
                --this.Count;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void InsertAt(T element, int position)
        {
            if (position > -1 && position < this.Count + 1)
            {
                T[] newArray = new T[this.Count + 1];
                for (int i = 0; i < position; i++)
                {
                    newArray[i] = this.array[i];
                }
                newArray[position] = element;
                for (int i = position; i < this.Count; i++)
                {
                    newArray[i + 1] = this.array[i];
                }

                this.array = newArray;
                this.capacity = newArray.Length;
                this.Count++;
                this.lastIndex++;

            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()
        {
            this.array = new T[0];
            this.Count = 0;
            this.lastIndex = -1;
            this.capacity = 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.capacity; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            string sb = string.Empty;
            for (int i = 0; i < this.Count; i++)
            {
                sb += this.array[i].ToString();
                sb += " ";
            }
            return sb;
        }

        public T Max()
        {
            return this.array.Max();
        }

        public T Min()
        {
            return this.array.Min();
        }

        private void Expand()
        {
            T[] newArray = new T[2 * this.capacity];
            for (int i = 0; i < this.capacity; i++)
            {
                newArray[i] = this.array[i];
            }
            this.array = newArray;
            this.capacity *= 2;
        }
    }
}
