using System;

namespace PriorityQueue
{
    public class MinPQ<T> where T : IComparable<T>
    {
        private T[] _queue;
        private int _count;

        public int Count => _count;
        public MinPQ(int N)
        {
            _queue = new T[N + 1];
        }

        public void Insert(T node)
        {
            int index = ++_count;
            _queue[index] = node;
            Swim(index);
        }

        public T DelMin()
        {
            T minNode = _queue[1];
            _queue[1] = _queue[_count];
            _queue[_count--] = default(T);
            Sink(1);
            return minNode;
        }

        private void Swim(int k)
        {
            while (k > 1)
            {
                if (_queue[k].CompareTo(_queue[k / 2]) < 0)
                {
                    Swap(_queue, k, k / 2);
                    k = k / 2;
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
                if (minChild + 1 <= _count && _queue[minChild].CompareTo(_queue[minChild + 1]) > 0) minChild++;

                if (_queue[k].CompareTo(_queue[minChild]) > 0)
                {
                    Swap(_queue, k, minChild);
                    k = minChild;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(T[] a, int i, int j)
        {
            T tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}