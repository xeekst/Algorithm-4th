using System;

namespace SymbolTable
{
    public class ArrayST<TKey, TValue> : IST<TKey, TValue> where TKey : IComparable
    {
        private int _count;
        private Node<TKey, TValue>[] _array;

        public ArrayST(int N)
        {
            _array = new Node<TKey, TValue>[N];
        }

        public int Count { get => _count; }

        public Node<TKey, TValue> this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return _array[index];
            }
        }

        public void Put(TKey key, TValue value)
        {
            if (Count == _array.Length) Resize(2 * _array.Length);
            var node = Get(key);
            if (node == null)
            {
                node = new Node<TKey, TValue>(key, value);
                _array[_count++] = node;
            }
            else
            {
                node.Value = value;
            }
        }

        public bool Contains(TKey key)
        {
            if (Get(key) != null)
            {
                return true;
            }
            return false;
        }

        public Node<TKey, TValue> Get(TKey key)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Key.CompareTo(key) == 0)
                {
                    return _array[i];
                }
            }
            return null;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public Node<TKey, TValue> Delete(TKey key)
        {
            int findIndex = -1;
            Node<TKey, TValue> targetNode = null;
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Key.CompareTo(key) == 0)
                {
                    findIndex = i;
                    targetNode = _array[i];
                    break;
                }
            }
            for (int i = findIndex; i < _count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            // 如若找到了元素，就删除最后一个
            if (targetNode != null)
            {
                _array[--_count] = null;
            }

            return targetNode;
        }

        private void Resize(int N)
        {
            var oldArray = _array;
            _array = new Node<TKey, TValue>[N];
            for (int i = 0; i < oldArray.Length; i++)
            {
                _array[i] = oldArray[i];
            }
            oldArray = null;
        }
    }
}
