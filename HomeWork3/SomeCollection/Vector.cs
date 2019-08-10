using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeCollection
{
    /*
     * Жалкая попытка повторить std vector mini
     */
    class Vector<T> : IEnumerable
    {
        T[] ArrayVector;
        public Vector()
        {
            this.ArrayVector = new T[0];
            this.Lenght = 0;
        }

        public int Lenght { get; private set; }
        public void PushFront(T value)
        {
            this.ArrayVector = ArrCopyF();
            this.ArrayVector[0] = value;
            this.Lenght++;
        }
        public void PushFront(Vector<T> value)
        {
            this.ArrayVector = ArrCopyF(value.Lenght);
            for (int i = 0; i < value.Lenght; i++)
            {
                this.ArrayVector[i] = value[i];
            }

            this.Lenght += value.Lenght;
        }
        public void PushBack(T value)
        {
            this.ArrayVector = ArrCopyB();
            this.ArrayVector[this.Lenght] = value;
            this.Lenght++;
        }
        T[] ArrCopyF(int addLenght = 1)
        {
            T[] TempArr = new T[this.Lenght + addLenght];
            for (int i = addLenght, y=0 ; i < TempArr.Length; i++,y++)
            {
                TempArr[i] = this.ArrayVector[y];
            }
            return TempArr;
        }
        public void PushBack(Vector<T> value)
        {
            this.ArrayVector = ArrCopyB(value.Lenght);
            for (int i = this.Lenght , y = 0; i < this.Lenght + value.Lenght; i++, y++)
            {
                this.ArrayVector[i] = value[y];
            }
           
            this.Lenght+= value.Lenght;
        }
        T[] ArrCopyB(int addLenght = 1)
        {
            T[] TempArr = new T[this.Lenght + addLenght];
            for (int i = 0; i < this.ArrayVector.Length; i++)
            {
                TempArr[i] = this.ArrayVector[i];
            }
            return TempArr;
        }
        public bool RemoveAt(int index, int count)
        {
            if (index >= this.Lenght) return false;
            else
            {
                if (count >= this.Lenght) count = this.Lenght - 1;
                T[] TempArr = new T[this.Lenght - ((count + 1) - index)];
                int i = 0;
                int y = 0;
                if (TempArr.Length != 0)
                {
                    for (i = 0, y = 0; i < index; i++, y++)
                    {
                        TempArr[y] = this.ArrayVector[i];
                    }
                    i += count;

                    for (; i < this.ArrayVector.Length; i++, y++)
                    {
                        TempArr[y] = this.ArrayVector[i];

                    }
                }
                this.ArrayVector = TempArr;
                this.Lenght -= ((count + 1) - index);
                return true;
            }
        }
        public bool RemoveAt(int index)
        {
            if (index >= this.Lenght) return false;
            else
            {
                T[] TempArr = new T[this.Lenght - 1];
                int i = 0;
                int y = 0;
                for (i = 0, y = 0; i < index; i++, y++)
                {
                    TempArr[y] = this.ArrayVector[i];
                }
                i++;
                for (; i < this.ArrayVector.Length; i++, y++)
                {
                    TempArr[y] = this.ArrayVector[i];

                }
                this.ArrayVector = TempArr;
                this.Lenght--;
                return true;
            }
        }
        public string toString()
        {
            return String.Empty;
        }
        public T this[int index]
        {
            get
            {
                if (index >= this.Lenght) throw new IndexOutOfRangeException();
                else return this.ArrayVector[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }
    }
    class MyEnumerator<T> : IEnumerator
    {
        Vector<T> vector;
        T curentItems;
        int index = -1;
        public MyEnumerator(Vector<T> vk)
        {
            vector = vk;
        }
        public object Current => curentItems;
        public bool MoveNext()
        {
            if ((index++) >= vector.Lenght - 1) return false;
            else
            {
                curentItems = vector[index];
                return true;
            }
        }
        public void Reset()
        {
            index = -1;
        }
    }
}
