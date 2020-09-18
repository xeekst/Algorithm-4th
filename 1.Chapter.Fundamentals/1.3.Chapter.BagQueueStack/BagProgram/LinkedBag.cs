using System;
using System.Collections;
using System.Collections.Generic;

namespace BagProgram
{
    public class LinkedBag<TData> : IBag<TData>
    {
        private Node<TData> _head;
        private int _count = 0;
        public int Count { get => _count; }

        public void Add(TData data)
        {
            Node<TData> node = new Node<TData>
            {
                data = data
            };
            Node<TData> oldHead = _head;
            _head = node;
            _head.next = oldHead;
            _count++;
        }

        public void ForEach(Action<Node<TData>> action)
        {
            Node<TData> node = _head;
            do
            {
                if (node == null) break;
                action(node);
                node = node.next;
            } while (node != null);
            node = null;
        }
    }
}
