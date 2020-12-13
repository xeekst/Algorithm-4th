namespace DataCompress
{
    public class ThreeTrieST<TValue>
    {
        private class Node
        {
            public char Ch;
            public Node Left, Right, Mid;
            public TValue Value;
        }
        private Node _root;

        public TValue Get(string pat)
        {
            Node x = Get(_root, pat, 0);
            return x == null ? default(TValue) : x.Value;
        }

        private Node Get(Node x, string pat, int d)
        {
            if (x == null) return null;
            char ch = pat[d];
            int cmp = ch.CompareTo(x.Ch);
            if (cmp < 0)
            {
                return Get(x.Left, pat, d);
            }
            else if (cmp > 0)
            {
                return Get(x.Right, pat, d);
            }
            else
            {
                //当前char匹配上了 且 未到最后一个char
                if (d < pat.Length - 1)
                {
                    return Get(x.Mid, pat, d + 1);
                }
                //到了最后一个char
                return x;
            }
        }

        public void Put(string pat, TValue value)
        {
            if (string.IsNullOrEmpty(pat)) return;
            _root = Put(_root, pat, 0, value);
        }

        private Node Put(Node x, string pat, int d, TValue value)
        {
            char ch = pat[d];
            if (x == null) x = new Node() { Ch = ch };
            int cmp = ch.CompareTo(x.Ch);
            if (cmp < 0)
            {
                x.Left = Put(x.Left, pat, d, value);
            }
            else if (cmp > 0)
            {
                x.Right = Put(x.Right, pat, d, value);
            }
            else
            {
                if (d == pat.Length - 1)
                {
                    x.Value = value;
                }
                else
                {
                    x.Mid = Put(x.Mid, pat, d + 1, value);
                }
            }

            return x;
        }

        public string LongestPrefixOf(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            Node x = _root;
            int d = 0;
            int len = 0;
            while (x != null && d < s.Length)
            {
                char ch = s[d];
                int cmp = ch.CompareTo(x.Ch);
                if (cmp < 0)
                {
                    x = x.Left;
                }
                else if (cmp > 0)
                {
                    x = x.Right;
                }
                else
                {
                    d++;
                    if (x.Value != null)
                    {
                        len = d;
                    }
                    x = x.Mid;
                }
            }
            return s.Substring(0, len);
        }
    }
}