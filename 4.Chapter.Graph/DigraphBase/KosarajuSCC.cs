using System;

namespace DigraphBase
{
    //计算强连通分量
    public class KosarajuSCC
    {
        private bool[] marked;
        private int[] id;
        private int count;

        public KosarajuSCC(Digraph g)
        {
            marked = new bool[g.V()];
            id = new int[g.V()];
            DepthFirstOrder order = new DepthFirstOrder(g.Reverse());
            foreach (int s in order.Reverse)
            {
                if (!marked[s])
                {
                    Dfs(g, s);
                    count++;
                }
            }
        }

        public bool StronglyConnected(int v, int w)
        {
            return id[v] == id[w];
        }

        public int Id(int v)
        {
            return id[v];
        }

        public int Count()
        {
            return count;
        }

        private void Dfs(Digraph g, int v)
        {
            marked[v] = true;
            id[v] = count;
            foreach (int w in g.Adj(v))
            {
                if (!marked[w])
                {
                    Dfs(g, w);
                }
            }
        }
    }
}
