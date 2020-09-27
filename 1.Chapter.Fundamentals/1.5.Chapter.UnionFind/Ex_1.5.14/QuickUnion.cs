using System;

namespace Ex_1._5._14
{
    public class QuickUnion
    {
        private int[] _ids;
        private int _count;
        private int[] _hs;
        public QuickUnion(int n)
        {
            _ids = new int[n];
            for (int i = 0; i < _ids.Length; i++)
            {
                _ids[i] = i;
                _hs[i] = 0;
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

            // 两个树高度相等才增加树高度
            if (_hs[pRoot] == _hs[qRoot])
            {
                _ids[pRoot] = _ids[qRoot];
                _hs[qRoot]++;
            }
            else if (_hs[pRoot] < _hs[qRoot])
            {
                _ids[pRoot] = _ids[qRoot];
            }
            else
            {
                _ids[qRoot] = _ids[pRoot];
            }
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
