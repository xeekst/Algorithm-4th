using System;

namespace UnionFind
{
    public class WeightedUF
    {
        private int[] _ids;
        private int[] _sz;
        private int _count;
        public WeightedUF(int n)
        {
            _ids = new int[n];
            _sz = new int[n];
            for (int i = 0; i < _ids.Length; i++)
            {
                _ids[i] = i;
                _sz[i] = 1;
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

            if (_sz[pRoot] < _sz[qRoot])
            {
                _ids[pRoot] = _ids[qRoot];
                _sz[qRoot] += _sz[pRoot];
            }
            else
            {
                _ids[qRoot] = _ids[pRoot];
                _sz[pRoot] += _sz[qRoot];
            }

            _count--;
        }

    }
}
