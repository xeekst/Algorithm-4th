using System.Collections.Generic;

namespace ShortestPath
{
    public class EdgeWeightedDigraph
    {
        private int _V; //顶点数
        private int _E; //边数

        private HashSet<DirectedEdge>[] _adj;

        public EdgeWeightedDigraph(int v)
        {
            _V = v;
            _E = 0;
            _adj = new HashSet<DirectedEdge>[v];
            for (int s = 0; s < _V; s++)
            {
                _adj[s] = new HashSet<DirectedEdge>();
            }
        }

        public int V => _V;
        public int E => _E;

        public void AddEdge(DirectedEdge e)
        {
            _adj[e.From].Add(e);
            _E++;
        }

        public HashSet<DirectedEdge> Adj(int v)
        {
            return _adj[v];
        }

        public HashSet<DirectedEdge> Edges()
        {
            HashSet<DirectedEdge> edges = new HashSet<DirectedEdge>();
            for (int v = 0; v < _V; v++)
            {
                foreach (DirectedEdge e in _adj[v])
                {
                    edges.Add(e);
                }
            }
            return edges;
        }
    }
}