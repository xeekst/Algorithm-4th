namespace GraphBase
{
    public class Cycle
    {
        private bool[] _marked;
        private bool _hasCycle;

        public Cycle(Graph g)
        {
            _marked = new bool[g.V()];
            _hasCycle = false;
            for (int s = 0; s < g.V(); s++)
            {
                if (!_marked[s])
                {
                    Dfs(g, s, s);
                }
            }
        }

        // 在一个连通分量里面搜索
        private void Dfs(Graph g, int v, int p)
        {
            _marked[v] = true;
            foreach (int w in g.Adj(v))
            {
                if (!_marked[w])
                {
                    Dfs(g, w, v);
                }
                //连接到了marked的某个顶点上
                else if (w != p) _hasCycle = true;
            }
        }

        public bool HasCycle()
        {
            return _hasCycle;
        }
    }
}