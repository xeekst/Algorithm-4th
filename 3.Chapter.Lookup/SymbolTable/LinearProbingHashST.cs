using System;

namespace SymbolTable
{
    public class LinearProbingHashST<TKey, TValue> : IST<TKey, TValue> where TKey : IComparable
    {
        private int HASH_SIZE = 0;
        private int _count = 0;
        private Node<TKey, TValue>[] _nodes;
        public int Count => _count;

        public LinearProbingHashST(int N)
        {
            _nodes = new Node<TKey, TValue>[N];
            HASH_SIZE = N;
        }

        public bool Contains(TKey key)
        {
            int hashIndex = GetHashIndex(key);
            for (int i = hashIndex; _nodes[i] != null; i = (i + 1) % HASH_SIZE)
            {
                if (_nodes[i].Key.Equals(key)) return true;
            }
            return false;
        }

        public Node<TKey, TValue> Delete(TKey key)
        {
            if (!Contains(key)) return null;
            int hashIndex = GetHashIndex(key);
            while (!key.Equals(_nodes[hashIndex].Key))
            {
                hashIndex = (hashIndex + 1) % HASH_SIZE;
            }
            var deletedNode = _nodes[hashIndex];
            _nodes[hashIndex] = null;
            hashIndex = (hashIndex + 1) % HASH_SIZE;
            for (; _nodes[hashIndex] != null; hashIndex = (hashIndex + 1) % HASH_SIZE)
            {
                var node = _nodes[hashIndex];
                _nodes[hashIndex] = null;
                // 因为后面的Put会 _count++
                _count--;
                Put(node.Key, node.Value);
            }
            _count--;
            return deletedNode;
        }

        public Node<TKey, TValue> Get(TKey key)
        {
            int hashIndex = GetHashIndex(key);

            for (; _nodes[hashIndex] != null; hashIndex++)
            {
                if (_nodes[hashIndex].Key.Equals(key))
                {
                    return _nodes[hashIndex];
                }
            }
            return null;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public void Put(TKey key, TValue value)
        {
            if (_count >= HASH_SIZE / 2) Resize(2 * HASH_SIZE);
            int hashIndex = GetHashIndex(key);

            for (; _nodes[hashIndex] != null; hashIndex = (hashIndex + 1) % HASH_SIZE)
            {
                if (_nodes[hashIndex].Key.Equals(key))
                {
                    _nodes[hashIndex].Value = value;
                    return;
                }
            }
            _nodes[hashIndex] = new Node<TKey, TValue>(key, value);
            _count++;
        }

        private int GetHashIndex(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % HASH_SIZE;
        }

        private void Resize(int N)
        {
            HASH_SIZE = N;
            var st = new LinearProbingHashST<TKey, TValue>(N);

            for (int i = 0; i < _nodes.Length; i++)
            {
                if (_nodes[i] != null)
                {
                    st.Put(_nodes[i].Key, _nodes[i].Value);
                }

            }
            _nodes = st._nodes;
        }
    }
}
