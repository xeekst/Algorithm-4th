using System.Collections.Generic;

namespace ShortestPath
{
    public class DijkstraSP
    {
        private DirectedEdge[] _edgeTo;
        private double[] _distTo;
        private IndexMinPQ<double> _pq;

        public DijkstraSP(EdgeWeightedDigraph g, int s)
        {
            _edgeTo = new DirectedEdge[g.V];
            _distTo = new double[g.V];
            _pq = new IndexMinPQ<double>(g.V * g.V);
            for (int i = 0; i < g.V; i++)
            {
                _distTo[i] = double.PositiveInfinity;
            }
            _distTo[s] = 0;
            _pq.Insert(s, 0);
            while (_pq.Count > 0)
            {
                Relax(g, _pq.DelMin());
            }
        }

        public void Relax(EdgeWeightedDigraph g, int v)
        {
            foreach (DirectedEdge e in g.Adj(v))
            {
                int w = e.To;
                if (_distTo[w] > _distTo[v] + e.Weight)
                {
                    _distTo[w] = _distTo[v] + e.Weight;
                    _edgeTo[w] = e;
                    if (_pq.Contains(w)) _pq.Change(w, _distTo[w]);
                    else _pq.Insert(w, _distTo[w]);
                }
            }
        }

        public double DistTo(int v)
        {
            return _distTo[v];
        }

        public bool HasPath(int v)
        {
            throw new System.Exception();
        }

        public HashSet<DirectedEdge> PathTo(int v)
        {
            HashSet<DirectedEdge> set = new HashSet<DirectedEdge>();
            DirectedEdge e = _edgeTo[v];
            
            while (e != null)
            {
                set.Add(e);
                e = _edgeTo[e.From];
            }
            return set;
        }
    }
}