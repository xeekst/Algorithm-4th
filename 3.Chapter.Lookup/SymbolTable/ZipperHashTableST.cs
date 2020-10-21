using System;

using System.Linq;

namespace SymbolTable
{
    //基于拉链法的散列表实现
    public class ZipperHashTableST<TKey, TValue> : IST<TKey, TValue> where TKey : IComparable
    {
        private int HASH_SIZE = 10;
        private int _count = 0;
        private int MAX_ST_LEN = 400;

        public int Count => _count;

        private ArrayST<TKey, TValue>[] _arraySTs;

        public ZipperHashTableST(int M)
        {
            HASH_SIZE = M;
            _arraySTs = new ArrayST<TKey, TValue>[M];
            for (int i = 0; i < _arraySTs.Length; i++)
            {
                _arraySTs[i] = new ArrayST<TKey, TValue>(100);
            }
        }

        public bool Contains(TKey key)
        {
            return Get(key) != null;
        }

        public Node<TKey, TValue> Delete(TKey key)
        {
            int hashIndex = GetHashIndex(key);
            var node = _arraySTs[hashIndex]?.Delete(key);
            if (node != null) _count--;
            return node;
        }

        public Node<TKey, TValue> Get(TKey key)
        {
            int hashIndex = GetHashIndex(key);
            return _arraySTs[hashIndex]?.Get(key);
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public void Put(TKey key, TValue value)
        {
            int hashIndex = GetHashIndex(key);
            var arrayST = _arraySTs[hashIndex];
            int oldCount = arrayST.Count;
            arrayST.Put(key, value);
            if (arrayST.Count > oldCount) _count++;
            if (arrayST.Count > MAX_ST_LEN) Resize(2 * _arraySTs.Length);
        }

        private int GetHashIndex(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % HASH_SIZE;
        }

        private void Resize(int N)
        {
            var oldArraySTs = _arraySTs;
            HASH_SIZE = N;
            _arraySTs = new ArrayST<TKey, TValue>[N];
            for (int i = 0; i < oldArraySTs.Length; i++)
            {
                _arraySTs[i] = new ArrayST<TKey, TValue>(oldArraySTs.Length * 2);
                if (oldArraySTs[i] != null)
                {
                    for (int j = 0; j < oldArraySTs[i].Count; j++)
                    {
                        var node = oldArraySTs[i][j];
                        _arraySTs[i].Put(node.Key, node.Value);
                    }
                }
            }
        }
    }
}
