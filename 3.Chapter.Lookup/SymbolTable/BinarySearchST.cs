using System;

namespace SymbolTable
{
    public class BinarySearchST<TKey, TValue> : IST<TKey, TValue> where TKey : IComparable
    {
        private int _count;
        private Node<TKey, TValue>[] _orderedArray;
        public int Count { get => _count; }

        public BinarySearchST(int N)
        {
            _orderedArray = new Node<TKey, TValue>[N];
        }
        public bool Contains(TKey key)
        {
            int k = Rank(key);
            if (k < _count && _orderedArray[k].Key.CompareTo(key) == 0)
            {
                return true;
            }
            return false;
        }

        public Node<TKey, TValue> Delete(TKey key)
        {
            int k = Rank(key);
            if (k < _count && _orderedArray[k].Key.CompareTo(key) == 0)
            {
                var node = _orderedArray[k];
                for (int i = k; i < _count - 1; i++)
                {
                    _orderedArray[i] = _orderedArray[i + 1];
                }
                _orderedArray[--_count] = null;
                return node;
            }
            return null;
        }

        public Node<TKey, TValue> Get(TKey key)
        {
            int k = Rank(key);
            if (k < _count && _orderedArray[k].Key.CompareTo(key) == 0)
            {
                return _orderedArray[k];
            }
            return null;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public void Put(TKey key, TValue value)
        {
            int k = Rank(key);
            if (k < _count && _orderedArray[k].Key.CompareTo(key) == 0)
            {
                _orderedArray[k].Value = value;
                return;
            }
            for (int i = _count; i > k; i--)
            {
                _orderedArray[i] = _orderedArray[i - 1];
            }
            _count++;
            _orderedArray[k] = new Node<TKey, TValue>(key, value);
        }

        // 返回该key应该存的index
        private int Rank(TKey key)
        {
            int lo = 0;
            int hi = _count - 1;

            while (lo <= hi)
            {
                int m = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(_orderedArray[m].Key);
                switch (cmp)
                {
                    case 0:
                        return m;
                    case 1:
                        lo = m + 1;
                        break;
                    case -1:
                        hi = m - 1;
                        break;
                }
            }
            return lo;
        }
    }
}
