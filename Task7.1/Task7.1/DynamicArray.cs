using System;
using System.Reflection;

namespace Task7._1
{
    public class DynamicArray<T>
    {

        private T[] array;
        private int _size;
        private int _currentIndex;
        public int Lenght { get; set; }
        public DynamicArray()
        {
            array = new T[_size];
            Lenght = array.Length;
        }

        public void AddToEnd(T value)
        {
            if (array == null)
            {
                array = new T[1];
                _currentIndex = 0;
            }
            else if (_currentIndex == array.Length)
            {
                T[] newArray = new T[array.Length * 2];
                Array.Copy(array, newArray, array.Length);
                array = newArray;
            }
            array[_currentIndex] = value;
            _currentIndex++;
        }

        public void RemoveElement(int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
            }

            array[index] = default;
        }

        public T GetByIndex(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
            }

            return array[index];
        }
    }
}
