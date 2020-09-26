using System;

namespace UnionFind
{
    public class QuickFind
    {
        private int[] _ids;
        private int _count;
        public QuickUnion(int n)
        {
            for (int i = 0; i < _ids.Length; i++)
            {
                _ids[i] = i;
            }
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

            for (int i = 0; i < _ids.Length; i++)
            {
                if (_ids[i] == pRoot)
                {
                    _ids[i] = qRoot;
                }
            }
            _count--;
        }

    }
}
