using System.Collections.Generic;

namespace RegularExpression
{
    public class DirectedDFS
    {
        private bool[] _marked;
        public DirectedDFS(Digraph g, int s)
        {
            _marked = new bool[g.V()];
            Dfs(g, s);
        }
        public DirectedDFS(Digraph g, HashSet<int> sources)
        {
            _marked = new bool[g.V()];
            foreach (int s in sources)
            {
                if (!_marked[s]) Dfs(g, s);
            }
        }

        private void Dfs(Digraph g, int s)
        {
            _marked[s] = true;
            foreach (int w in g.Adj(s))
            {
                if (!_marked[w])
                {
                    Dfs(g, w);
                }
            }
        }

        public bool Reachable(int v)
        {
            return _marked[v];
        }
    }
}