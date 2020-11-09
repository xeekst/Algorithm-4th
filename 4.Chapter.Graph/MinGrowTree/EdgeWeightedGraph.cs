using System.Collections.Generic;

namespace MinGrowTree
{
    public class EdgeWeightedGraph
    {
        private int _V;
        private int _E;

        private HashSet<Edge>[] _adj;

        public EdgeWeightedGraph(int v)
        {
            _V = v;
            _adj = new HashSet<Edge>[v];
            for (int i = 0; i < v; i++)
            {
                _adj[i] = new HashSet<Edge>();
            }
        }

        public void AddEdge(Edge e)
        {
            int v = e.ThisVertex();
            int w = e.OtherVertex(v);
            _adj[v].Add(e);
            _adj[w].Add(e);
            _E++;
        }

        public HashSet<Edge> Adj(int v)
        {
            return _adj[v];
        }

        public int V()
        {
            return _V;
        }

        public int E()
        {
            return _E;
        }

        public HashSet<Edge> Edges()
        {
            HashSet<Edge> set = new HashSet<Edge>();
            for (int v = 0; v < _V; v++)
            {
                foreach (var e in _adj[v])
                {
                    if (e.OtherVertex(v) > v) set.Add(e);
                }
            }
            return set;
        }
    }
}