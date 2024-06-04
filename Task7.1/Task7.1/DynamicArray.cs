using System;
using System.Reflection;

namespace Task7._1
{
    public class DynamicArray<T>
    {
        private T[] _array;
        private int _size;
        private int _currentIndex;
        public int Lenght { get; set; }
        public DynamicArray()
        {
            _array = new T[_size];
            Lenght = _array.Length;
        }

        public void AddToEnd(T value)
        {
            if (_array == null)
            {
                _array = new T[1];
                _currentIndex = 0;
            }
            else if (_currentIndex == _array.Length)
            {
                T[] newArray = new T[_array.Length * 2];
                Array.Copy(_array, newArray, _array.Length);
                _array = newArray;
            }
            _array[_currentIndex] = value;
            _currentIndex++;
        }

        public void RemoveElement(int index)
        {
            if (index < 0 || index >= _array.Length)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
            }

            _array[index] = default;
        }

        public T GetByIndex(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
            }

            return _array[index];
        }
    }
}
