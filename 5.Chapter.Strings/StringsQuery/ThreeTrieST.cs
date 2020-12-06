namespace StringsQuery
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
            switch (ch.CompareTo(x.Ch))
            {
                case 1:
                    return Get(x.Right, pat, d);
                case -1:
                    return Get(x.Left, pat, d);
                default:
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
            if(string.IsNullOrEmpty(pat)) return;
            _root = Put(_root, pat, 0, value);
        }

        private Node Put(Node x, string pat, int d, TValue value)
        {
            char ch = pat[d];
            if (x == null) x = new Node() { Ch = ch };
            switch (ch.CompareTo(x.Ch))
            {
                case 0:
                    if (d == pat.Length - 1)
                    {
                        x.Value = value;
                    }
                    else
                    {
                        x.Mid = Put(x.Mid, pat, d + 1, value);
                    }
                    break;
                case 1:
                    x.Right = Put(x.Right, pat, d, value);
                    break;
                case -1:
                    x.Left = Put(x.Left, pat, d, value);
                    break;
            }
            return x;
        }
    }
}