namespace Example_2.Dictionary
{
    public class RofloClass
    {
        public SukaClass GetEnumerator()
        {
            return new SukaClass();
        }
    }

    public class SukaClass
    {
        public int Count = 0;
        public int Current => 4;

        public bool MoveNext()
        {
            if (Count >= 5)
            {
                return false;
            }
            Count++;
            return true;

        }
    }
}