
using System;
using System.Collections.Generic;

namespace StringsQuery
{

    public class TrieST<T> where T : IComparable
    {
        public class Node<TValue>
        {
            public Node()
            {
                nexts = new Node<TValue>[R];
            }
            public TValue value;
            public Node<TValue>[] nexts;
        }
        private static int R;
        private int _count = 0;
        private Node<T> _root;

        public int Count => _count;
        public TrieST(int r)
        {
            R = r;
        }

        public T GetValue(string key)
        {
            Node<T> x = GetValue(_root, key, 0);
            return x == null ? default(T) : x.value;
        }

        private Node<T> GetValue(Node<T> x, string key, int d)
        {
            if (x == null) return null;
            if (d == key.Length) return x;
            //找到当前比较的char
            char ch = key[d];
            return GetValue(x.nexts[ch], key, d + 1);
        }

        public void Put(string key, T val)
        {
            _root = Put(_root, key, val, 0);
        }

        private Node<T> Put(Node<T> x, string key, T val, int d)
        {
            if (x == null) x = new Node<T>();
            if (d == key.Length)
            {
                if (x.value == null)
                {
                    _count++;
                }
                x.value = val;
                return x;
            }
            char ch = key[d];
            x.nexts[ch] = Put(x.nexts[ch], key, val, d + 1);
            return x;
        }
        // ToDo
        public void Delete(string key)
        {

        }

        public bool Contains(string key)
        {
            return false;
        }

        public string LongestPrefixOf(string key)
        {
            return null;
        }

        //通配符.匹配
        public IList<string> KeysThatMach(string pat)
        {
            IList<string> list = new List<string>();
            Collect(_root, "", pat, list);
            return list;
        }

        private void Collect(Node<T> x, string pre, string pat, IList<string> list)
        {
            int d = pre.Length;
            if (d == pat.Length)
            {
                if (x.value != null)
                {
                    list.Add(pre);
                }
                return;
            }

            char next = pat[d];
            for (char c = (char)0; c < R; c++)
            {
                if (next == '.' || next == c)
                {
                    Collect(x.nexts[c], pre + c, pat, list);
                }
            }
        }

        public IList<string> KeysWithPrefix(string key)
        {
            return null;
        }
    }
}