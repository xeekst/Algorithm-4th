using System;

namespace PriorityQueue
{
    public class PriorityQueueImpl<T> where T : IComparable
    {
        private T[] _queue;
        private int _count;

        public int Count => _count;
        public PriorityQueueImpl(int N)
        {
            _queue = new T[N + 1];
        }

        public void Insert(T node)
        {
            int index = ++_count;
            _queue[index] = node;
            Swim(index);
        }

        public T DelMax()
        {
            T maxNode = _queue[1];
            _queue[1] = _queue[_count];
            _queue[_count] = default(T);
            Sink(1);
            _count--;
            return maxNode;
        }

        private void Swim(int k)
        {
            while (k > 1)
            {
                if (_queue[k].CompareTo(_queue[k / 2]) > 0)
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
            while (2 * k <= Count)
            {
                int maxChild = 2 * k;
                //找到两个子节点 更大的那个节点
                if (maxChild + 1 <= _count && _queue[maxChild].CompareTo(_queue[maxChild + 1]) < 0) maxChild++;
                //如果 k 小于最大的节点，那就下沉交换
                if (_queue[k].CompareTo(_queue[maxChild]) < 0)
                {
                    Swap(_queue, k, maxChild);
                    k = maxChild;
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