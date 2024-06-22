using System;
using System.Reflection;

namespace Task7._1
{
    public class DynamicArray<Y>
    {
        private Y[] _array;
        private int _size;
        private int _currentIndex;
        public int Length { get; set; }

        public DynamicArray()
        {
            _size = 1;
            _array = new Y[_size];
            Length = 0;
        }

        public void AddToEnd(Y value)
        {
            if (_currentIndex == _array.Length)
            {
                Y[] newArray = new Y[_array.Length * 2];
                Array.Copy(_array, newArray, _array.Length);
                _array = newArray;
                _size = _array.Length;
            }
            if (value == null ) 
            { 
            throw new ArgumentNullException("Нельзя передавать null");
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

        public Y GetByIndex(int index)
        {
            if (index < 0 || index >= _currentIndex)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы диапазона");
            }           
            return _array[index];
        }
    }
}
