using System.Text;
namespace Example_2.Dictionary
{
    public class MyDictionary<TKey, TValue>
    {
        private List<(TKey, TValue)>[] _buckets;
        private const int BucketSize = 3;

        public MyDictionary()
        {
            _buckets = new[]
            {
                new List<(TKey, TValue)>(), new List<(TKey, TValue)>()
            };
        }

        public void Add(TKey key, TValue value)
        {
            var index = GetIndex(key);
            _buckets[index].Add((key, value));

            if (_buckets[index].Count > BucketSize)
            {
                Resize();
            }
        }

        public TValue Get(TKey key)
        {
            var index = GetIndex(key);
            var pair = _buckets[index].FirstOrDefault(x => x.Item1.Equals(key));
            if (pair.Equals(default))
            {
                throw new ArgumentException("Not Found");
            }

            return pair.Item2;
        }

        public void Remove(TKey key, TValue value)
        {
            var index = GetIndex(key);
            var pair = _buckets[index].FirstOrDefault(x => x.Item1.Equals(key));
            if (pair.Equals(default))
            {
                throw new ArgumentException("Not Found");
            }

            _buckets[index].Remove(pair);
        }

        private int GetIndex(TKey key)
        {
            var hash = Math.Abs(key.GetHashCode());
            return hash % _buckets.Length;
        }

        private void Resize()
        {
            var newBuckets = new List<(TKey, TValue)>[_buckets.Length * 2];
            for (var i = 0; i < newBuckets.Length; i++)
            {
                newBuckets[i] = new List<(TKey, TValue)>();
            }

            foreach (var bucket in _buckets)
            {
                foreach (var pair in bucket)
                {
                    var hash = Math.Abs(pair.Item1.GetHashCode());
                    var index = hash % newBuckets.Length;
                    newBuckets[index].Add(pair);
                }
            }

            _buckets = newBuckets;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var bucket in _buckets)
            {
                foreach (var (key, value) in bucket)
                {
                    stringBuilder.Append($"{key}:{value},");
                }
                stringBuilder.AppendLine();
            }
            stringBuilder.AppendLine("End map");
            return stringBuilder.ToString();
        }
    }
}