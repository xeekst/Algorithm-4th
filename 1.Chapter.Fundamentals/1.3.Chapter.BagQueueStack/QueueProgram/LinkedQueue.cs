using System;

namespace QueueProgram
{
    public class LinkedQueue<TData> : IQueue<TData>
    {
        private Node<TData> _head;
        private Node<TData> _last;
        private int _count = 0;

        public class Node<T>
        {
            public Node<T> next;
            public T data = default(T);
        }

        public TData Dequeue()
        {
            if(_head == null) throw new NullReferenceException();
            TData data = _head.data;
            _head = _head.next;
            _count--;
            return data;
        }

        public void Enqueue(TData data)
        {
            Node<TData> node = new Node<TData>()
            {
                data = data
            };
            var oldLast = _last;
            _last = node;
            if (_head == null) _head = _last;
            else oldLast.next = _last;
            _count++;
        }

        public int Size()
        {
            return _count;
        }
    }
}