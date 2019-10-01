using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17
{
    public class CustomCollection<T>:IEnumerable
    {
        private T[] array = null;
        public int Lenght { get => array.Length; }
        private int CurrentPosition;

        public CustomCollection()
        {
            array = new T[0];
            CurrentPosition = -1;
        }

        public void PushBack(T value)
        {
            T[] tempArray = new T[array.Length + 1];
            if (CurrentPosition != -1)
            {
                Parallel.For(0, array.Length, (i) => { tempArray[i] = array[i]; });
            }

            CurrentPosition++;
            array = tempArray;
            array[CurrentPosition] = value;
        }

        public void PushFront(T value)
        {
            T[] tempArray = new T[array.Length + 1];
            if (CurrentPosition != 0)
            {
                Parallel.For(0, array.Length, (i) => { tempArray[i+1] = array[i]; });
            }

            CurrentPosition++;
            array = tempArray;
            array[0] = value;
        }

        public void AddAt(int index,T value)
        {
            T[] tempArray = new T[array.Length + 1];
            if (CurrentPosition != 0)
            {
                Parallel.For(0, array.Length, (i) => { tempArray[i + 1] = array[i]; });
            }

            CurrentPosition++;
            array = tempArray;
            array[0] = value;
        }

        public bool RemoveAt(int index)
        {
            if (index >= 0 && index < array.Length)
            {
                T[] tempArray = new T[array.Length - 1];
                Parallel.For(0, index, (i) => { tempArray[i] = array[i]; });
                Parallel.For(index, tempArray.Length, (i) => { tempArray[i] = array[i+1]; });
                array = tempArray;
                CurrentPosition--;
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
                yield return array[i];
        }
    }
}
