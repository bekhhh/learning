namespace Example_2.Dictionary
{
    public class MyLinkedListV2<T>
    {
        private MyLinkedListV2<T> _next;
        private MyLinkedListV2<T> _current;
        private T _currentValue;
        public T CurrentValue => _currentValue;
        public MyLinkedListV2<T> Next => _next;

        public MyLinkedListV2(T value)
        {
            _currentValue = value;
        }

        public MyLinkedListV2(T[] array)
        {
            if (array.Length == 0 || array == null)
            {
                throw new ArgumentException();
            }

            _currentValue = array[0];
            
            if (array.Length > 1)
            {
                _next = new MyLinkedListV2<T>(array.Skip(1).ToArray());
            }
        }

        public T Current => _current.CurrentValue;

        public bool MoveNext()
        {
            if (_current == null)
            {
                _current = this;
                return true;
            }
            else
            {
                _current = _current.Next;
                return _current != null;
            }
        }
        public MyLinkedListV2<T> GetEnumerator()
        {
            return this;
        }
    }
}