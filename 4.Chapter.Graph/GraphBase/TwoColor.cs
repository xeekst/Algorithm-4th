namespace GraphBase
{
    public class TwoColor
    {
        private bool[] _marked;
        private bool[] _color;
        private bool _isTwoColorable = true;

        public bool IsTwoColorable => _isTwoColorable;
        public TwoColor(Graph g)
        {
            _marked = new bool[g.V()];
            for (int s = 0; s < g.V(); s++)
            {
                if (!_marked[s])
                {
                    Dfs(g, s);
                }
            }
        }

        private void Dfs(Graph g, int v)
        {
            _marked[v] = true;
            foreach (int w in g.Adj(v))
            {
                if (!_marked[w])
                {
                    _color[w] = !_color[v];
                    Dfs(g, w);
                }
                else if (_color[w] == _color[v])
                {
                    _isTwoColorable = false;
                }
            }
        }
    }
}