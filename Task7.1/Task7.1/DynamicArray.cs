using System;
using System.Reflection;

namespace Task7._1
{
    public class DynamicArray<T>
    {
        private T[] _array;
        private int _size;
        private int _currentIndex;
        public int Length { get; set; }

        public DynamicArray()
        {
            _size = 1;
            _array = new T[_size];
            Length = 0;
        }

        public void AddToEnd(T value)
        {
            if (_currentIndex == _array.Length)
            {
                T[] newArray = new T[_array.Length * 2];
                Array.Copy(_array, newArray, _array.Length);
                _array = newArray;
                _size = _array.Length;
            }
            _array[_currentIndex] = value;
            _currentIndex++;
            Length++;
        }

        public void RemoveElement(int index)
        {
            if (index < 0 || index >= _currentIndex)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
            }
            for (int i = index; i < _currentIndex - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            _array[_currentIndex - 1] = default;
            _currentIndex--;
            Length--;
        }

        public T GetByIndex(int index)
        {
            if (index < 0 || index >= _currentIndex)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
            }
            return _array[index];
        }
    }
}
