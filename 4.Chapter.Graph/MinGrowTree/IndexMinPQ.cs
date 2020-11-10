using System;
using System.Collections.Generic;

namespace MinGrowTree
{
    public class IndexMinPQ<T> where T : IComparable<T>
    {
        private int[] _indexK;
        private int[] _kindex;
        private T[] _keys;
        private int _count;

        public int Count => _count;
        public IndexMinPQ(int N)
        {
            _keys = new T[N + 1];
            _indexK = new int[N + 1];
            _kindex = new int[N + 1];
            for (int i = 0; i < N + 1; i++)
            {
                _kindex[i] = -1;
            }
        }

        public void Change(int k, T key)
        {
            _keys[k] = key;
            Swim(_kindex[k]);
            Sink(_kindex[k]);
        }

        public bool Contains(int k)
        {
            return _kindex[k] != -1;
        }
        public void Insert(int k, T value)
        {
            int index = ++_count;
            _kindex[k] = index;
            _indexK[index] = k;
            _keys[k] = value;
            Swim(index);
        }

        public int DelMin()
        {
            int minK = _indexK[1];
            _kindex[minK] = -1;
            _keys[minK] = default(T);
            _indexK[1] = _indexK[_count];
            _indexK[_count--] = default(int);
            Sink(1);
            return minK;
        }

        private bool Less(int i, int j)
        {
            var k1 = _indexK[i];
            var k2 = _indexK[j];
            return _keys[k1].CompareTo(_keys[k2]) < 0;
        }


        private void Swim(int i)
        {
            while (i > 1)
            {

                if (Less(i, i / 2))
                {
                    Swap(i, i / 2);
                    i = i / 2;
                }
                else
                {
                    break;
                }
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= _count)
            {
                int minChild = 2 * k;

                //找到两个子节点 更小的那个节点
                if (minChild + 1 <= _count && Less(minChild + 1, minChild)) minChild++;

                if (Less(minChild,k))
                {
                    Swap(k, minChild);
                    k = minChild;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int i, int j)
        {
            int tmp = _indexK[i];
            _indexK[i] = _indexK[j];
            _indexK[j] = tmp;

            _kindex[_indexK[i]] = i;
            _kindex[_indexK[j]] = j;
        }
    }
}