using System.Collections;

namespace Task7._1
{
    public class MyLinkedArray<T> : IEnumerable<T>
    {
        private MyLinkedArray<T> _next;
        private T _currentValue;

        public T CurrentValue => _currentValue;
        public MyLinkedArray<T> Next => _next;

        public MyLinkedArray(T value)
        {
            _currentValue = value;
        }

        public MyLinkedArray(T[] array, MyLinkedArray<T>? start = null)
        {
            if (array.Length == 0 || array == null)
            {
                throw new ArgumentException();
            }

            _currentValue = array[0];

            if (array.Length > 1)
            {
                _next = new MyLinkedArray<T>(array.Skip(1).ToArray());
            }
        }

        public MyLinkedArray(DynamicArray<T> dynamicArray)
        {
            if (dynamicArray.Length == 0)
            {
                throw new ArgumentException("DynamicArray is empty");
            }

            var array = new T[dynamicArray.Length];
            for (int i = 0; i < dynamicArray.Length; i++)
            {
                array[i] = dynamicArray[i];
            }

            _currentValue = array[0];

            if (array.Length > 1)
            {
                _next = new MyLinkedArray<T>(array.Skip(1).ToArray());
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Enumerator<T> : IEnumerator<T>
        {
            private MyLinkedArray<T> _start;
            private MyLinkedArray<T> _currentItem;

            public Enumerator(MyLinkedArray<T> list)
            {
                _start = list;
            }

            public bool MoveNext()
            {
                if (_currentItem == null)
                {
                    _currentItem = _start;
                    return true;
                }
                else
                {
                    _currentItem = _currentItem.Next;
                    return _currentItem != null;
                }
            }

            public void Reset()
            {
                _currentItem = _start;
            }

            public T Current => _currentItem.CurrentValue;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}
