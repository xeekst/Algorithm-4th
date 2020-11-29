
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

        public T GetValue(string pat)
        {
            Node<T> x = GetValue(_root, pat, 0);
            return x == null ? default(T) : x.value;
        }

        private Node<T> GetValue(Node<T> x, string pat, int d)
        {
            if (x == null) return null;
            if (d == pat.Length) return x;
            //找到当前比较的char
            char ch = pat[d];
            return GetValue(x.nexts[ch], pat, d + 1);
        }

        public void Put(string pat, T val)
        {
            _root = Put(_root, pat, val, 0);
        }

        private Node<T> Put(Node<T> x, string pat, T val, int d)
        {
            if (x == null) x = new Node<T>();
            if (d == pat.Length)
            {
                if (x.value == null)
                {
                    _count++;
                }
                x.value = val;
                return x;
            }
            char ch = pat[d];
            x.nexts[ch] = Put(x.nexts[ch], pat, val, d + 1);
            return x;
        }
        // ToDo
        public void Delete(string pat)
        {
            _root = Delete(_root, pat, 0);
        }

        private Node<T> Delete(Node<T> x, string pat, int d)
        {
            if (x == null) return null;
            if (d == pat.Length) x.value = default(T);
            else
            {
                char ch = pat[d];
                x.nexts[ch] = Delete(x.nexts[ch], pat, d + 1);
            }
            if (x.value != null) return x;
            // 找到下一个串，然后返回这一个 
            for (char ch = (char)0; ch < R; ch++)
            {
                if (x.nexts[ch] != null) return x;
            }
            return null;
        }

        public bool Contains(string pat)
        {
            return Contains(_root, pat, 0);
        }

        private bool Contains(Node<T> x, string pat, int d)
        {
            if (x == null) return false;
            if (d == pat.Length)
            {
                if (x.value != null)
                {
                    return true;
                }
                return false;
            }

            return Contains(x.nexts[pat[d]], pat, d + 1);
        }

        //获取最长前缀
        public string LongestPrefixOf(string pat)
        {
            int length = LongestPrefixOf(_root, pat, 0, 0);
            return pat.Substring(0, length);
        }

        private int LongestPrefixOf(Node<T> x, string s, int d, int length)
        {
            if (x == null) return length;
            if (x.value != null) length = d;
            if (d == s.Length) return length;
            char ch = s[d];
            return LongestPrefixOf(x.nexts[ch], s, d + 1, length);
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

        public IList<string> KeysWithPrefix(string pat)
        {
            var node = GetValue(_root, pat, 0);
            IList<string> list = new List<string>();
            KeysWithPrefix(_root, pat, list);
            return list;
        }

        private void KeysWithPrefix(Node<T> x, string pre, IList<string> list)
        {
            if (x == null) return;
            if (x.value != null) list.Add(pre);

            for (char ch = (char)0; ch < R; ch++)
            {
                KeysWithPrefix(x.nexts[ch], pre + ch, list);
            }
        }
    }
}