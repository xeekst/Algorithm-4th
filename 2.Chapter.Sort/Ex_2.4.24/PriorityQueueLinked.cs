using System;
using System.Collections;
using System.Collections.Generic;

namespace Ex_2_4_24
{
    public class PriorityQueueLinked<T> where T : IComparable
    {
        private class Node<TValue>
        {
            public Node(TValue data, Node<TValue> p, Node<TValue> left = null, Node<TValue> rigth = null)
            {
                Data = data;
                Parent = p;
                Left = left;
                Right = rigth;
            }
            public TValue Data;
            public Node<TValue> Parent;
            public Node<TValue> Left;
            public Node<TValue> Right;
        }
        
        private Node<T> _root;

        private int _count = 0;

        public int Count => _count;

        public void Insert(T value)
        {
            var node = InsertLastNode(value);
            Swim(node);
        }

        public T DelMax()
        {
            var node = _root.Data;
            var lastParent = GetNodeParent(_count);
            if (lastParent != null)
            {
                Node<T> last = null;
                if (lastParent.Right != null)
                {
                    last = lastParent.Right;
                    lastParent.Right = null;
                }
                else
                {
                    last = lastParent.Left;
                    lastParent.Left = null;
                }
                SwapData(_root, last);
                last = null;
                Sink(_root);
            }

            _count--;
            return node;
        }

        private Node<T> InsertLastNode(T value)
        {
            int nextIndex = _count + 1;
            var nextParent = GetNodeParent(nextIndex);
            if (nextParent == null)
            {
                _root = new Node<T>(value, null);
                _count++;
                return _root;
            }
            else
            {
                Node<T> node = null;
                if (nextParent.Left == null)
                {
                    nextParent.Left = new Node<T>(value, nextParent);
                    node = nextParent.Left;
                }
                else
                {
                    nextParent.Right = new Node<T>(value, nextParent);
                    node = nextParent.Right;
                }
                _count++;
                return node;
            }

        }

        private Node<T> GetNodeParent(int index)
        {
            if (index <= 1) return null;

            Node<T> next = _root;
            var stack = new Stack<int>();
            // 记录从root出发要寻找的路径
            while (index / 2 > 1)
            {
                index = index / 2;
                stack.Push(index);
            }

            // 按照路径找到要插入节点的父节点
            while (stack.Count > 0)
            {
                bool isLeft = stack.Pop() % 2 == 0;
                if (isLeft)
                {
                    next = next.Left;
                }
                else
                {
                    next = next.Right;
                }
            }
            return next;
        }

        private void Swim(Node<T> node)
        {
            var tmpNode = node;
            while (tmpNode?.Parent != null)
            {
                if (tmpNode.Data.CompareTo(tmpNode.Parent.Data) > 0)
                {
                    SwapData(tmpNode, tmpNode.Parent);
                    tmpNode = tmpNode.Parent;
                }
                else
                {
                    break;
                }
            }
        }

        private void Sink(Node<T> node)
        {
            while (node?.Left != null)
            {
                var maxNode = node.Left;
                if (node.Right != null && maxNode.Data.CompareTo(node.Right.Data) < 0) maxNode = node.Right;
                if (node.Data.CompareTo(maxNode.Data) < 0)
                {
                    SwapData(node, maxNode);
                    node = maxNode;
                }
                else
                {
                    break;
                }
            }
        }

        private void SwapData(Node<T> node1, Node<T> node2)
        {
            var data1 = node1.Data;
            node1.Data = node2.Data;
            node2.Data = data1;
        }
    }
}
