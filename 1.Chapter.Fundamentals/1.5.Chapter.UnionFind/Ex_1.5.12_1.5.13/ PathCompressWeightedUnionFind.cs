using System;

namespace Ex_1._5._12
{
    public class PathCompressWeightedUnionFind
    {
        private int[] _ids;
        private int[] _sz;

        private int _count;
        public PathCompressWeightedUnionFind(int n)
        {
            _ids = new int[n];
            _sz = new int[n];
            for (int i = 0; i < _ids.Length; i++)
            {
                _ids[i] = i;
                _sz[i] = 1;
            }
            _count = n;

        }
        public int Find(int p)
        {
            int current = p;
            while (_ids[p] != p)
            {
                p = _ids[p];
            }
            int path = 0;
            // 路径压缩 最长为path == 4
            while (_ids[current] != current)
            {
                if (path < 3)
                {
                    current = _ids[current];
                    path++;
                }
                else
                {
                    int nextNode = _ids[current];
                    _ids[current] = p;
                    current = nextNode;
                }
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
                _path[qRoot]++;
            }
            else
            {
                _ids[qRoot] = _ids[pRoot];
                _sz[pRoot] += _sz[qRoot];
                _path[pRoot]++;
            }

            _count--;
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Count => _count;
    }
}
