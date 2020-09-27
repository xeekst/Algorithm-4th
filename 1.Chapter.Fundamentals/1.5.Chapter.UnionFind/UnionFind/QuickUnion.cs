using System;

namespace UnionFind
{
    public class QuickUnion
    {
        private int[] _ids;
        private int _count;
        public QuickUnion(int n)
        {
            _ids = new int[n];
            for (int i = 0; i < _ids.Length; i++)
            {
                _ids[i] = i;
            }
            _count = n;
        }
        public int Find(int p)
        {
            while (_ids[p] != p)
            {
                p = _ids[p];
            }
            return p;
        }

        public void Union(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);

            if (pRoot == qRoot) return;

            _ids[pRoot] = _ids[qRoot];
            _count--;
        }
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Count => _count;
    }
}
