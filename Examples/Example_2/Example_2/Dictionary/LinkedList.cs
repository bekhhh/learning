using System.Collections;
namespace Example_2.Dictionary
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private MyLinkedList<T> _next;
        private T _currentValue;
        public T CurrentValue => _currentValue;
        public MyLinkedList<T> Next => _next;

        public MyLinkedList(T value)
        {
            _currentValue = value;
        }

        public MyLinkedList(T[] array, MyLinkedList<T>? start = null)
        {
            if (array.Length == 0 || array == null)
            {
                throw new ArgumentException();
            }

            _currentValue = array[0];
            
            if (array.Length > 1)
            {
                _next = new MyLinkedList<T>(array.Skip(1).ToArray());
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
            private MyLinkedList<T> _start;
            private MyLinkedList<T> _currentItem;
            
            public Enumerator(MyLinkedList<T> list)
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