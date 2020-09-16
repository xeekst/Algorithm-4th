using System;

namespace StackProgram
{
    /// <summary>
    /// 使用链表实现栈
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class LinkedStack<TValue> : IStack<TValue>
    {
        private Node<TValue> _root = null;
        private int _count = 0;
        public class Node<TData>
        {
            public TData data = default(TData);
            public Node<TData> next = null;
        }

        public LinkedStack() { }
        public bool IsEmpty()
        {
            return _count == 0;
        }

        public TValue Pop()
        {
            if (_root == null) throw new ArgumentOutOfRangeException();
            var oldRoot = _root;
            _root = _root.next;
            _count--;
            return oldRoot.data;
        }

        public void Push(TValue value)
        {
            var oldRoot = _root;
            Node<TValue> node = new Node<TValue>()
            {
                data = value,
                next = oldRoot
            };
            _root = node;
            _count++;
        }

        public int Size()
        {
            return _count;
        }
    }
}
