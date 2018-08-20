
namespace UnionF
{
    class UnionFind : IUnionFind
    {
        private int[] id;
        private int[] sz;
        public void Init(int n)
        {
            id = new int[n + 1];
            sz = new int[n + 1];
            for (int index = 0; index <= n; index++)
            {
                id[index] = index;
                sz[index] = 1;
            }
        }

        public bool connected(int i, int j)
        {
            if (Find(i) == Find(j))
            {
                return true;
            }
            return false;
        }

        public int Find(int i)
        {
            while (id[i] != i)
            {
                id[i] = id[id[i]];
                i = id[i];
            }
            return i;
        }
        public void Union(int i, int j)
        {
            int pi = Find(i);
            int pj = Find(j);
            if (sz[pi] >= sz[pj])
            {
                id[pj] = id[pi];
            }
            else
            {
                id[pi] = id[pj];
            }
        }
    }
}