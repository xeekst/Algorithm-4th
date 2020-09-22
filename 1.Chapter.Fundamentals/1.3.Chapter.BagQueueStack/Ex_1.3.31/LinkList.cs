using System.Collections;
using System;

namespace Ex_1._3._31
{
    public class LinkList<TData> : ILinkList<TData>
    {
        public DoubleNode<TData> _head;
        public DoubleNode<TData> _last;

        public int _count = 0;
        public DoubleNode<TData> Head => _head;
        public LinkList() { }

        public int Count { get => _count; }

        public TData DeleteHead()
        {
            if(_count == 0) throw new ArgumentOutOfRangeException();
            TData data = _head.Data;
            _head = _head.Next;
            _count--;
            return data;
        }

        public TData DeleteTail()
        {
            if(_count == 0) throw new ArgumentOutOfRangeException();
            DoubleNode<TData> oldLast = _last;
            TData data = oldLast.Data;
            _last = oldLast.Prev;
            _last.Next = null;
            _count--;
            return data;
        }

        public void InsertHead(TData data)
        {
            DoubleNode<TData> oldHead = _head;
            DoubleNode<TData> head = new DoubleNode<TData>
            {
                Data = data,
                Next = oldHead,
                Prev = null
            };
            if (_count++ == 0)
            {
                _last = head;
            }
            else oldHead.Prev = head;
            _head = head;

        }

        public void InsertTail(TData data)
        {
            DoubleNode<TData> oldLast = _last;
            DoubleNode<TData> last = new DoubleNode<TData>()
            {
                Data = data,
                Prev = oldLast,
                Next = null
            };
            if (_count++ == 0)
            {
                _head = last;
            }
            else
            {
                oldLast.Next = last;
            }
            _last = last;
        }

        public int Size()
        {
            return _count;
        }
    }
}