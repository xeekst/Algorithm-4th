namespace GraphBase
{
    // 连通分量
    public class CC
    {
        private bool[] _marked;
        private int[] _id;
        private int count;

        public CC(Graph g)
        {
            _marked = new bool[g.V()];
            _id = new int[g.V()];
            for (int s = 0; s < g.V(); s++)
            {

            }
        }

        private void Dfs(Graph g, int v)
        {
            _marked[v] = true;
            _id[v] = count;
            foreach (int w in g.Adj(v))
            {
                if (!_marked[w])
                {
                    Dfs(g, w);
                }
            }
        }

        public bool Connected(int v, int w)
        {
            return _id[v] == _id[w];
        }

        public int Id(int v)
        {
            return _id[v];
        }

        public int Count()
        {
            return count;
        }
    }
}