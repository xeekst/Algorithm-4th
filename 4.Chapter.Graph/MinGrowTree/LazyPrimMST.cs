using System.Collections.Generic;

namespace MinGrowTree
{
    public class LazyPrimMST
    {
        private bool[] _marked;
        private Queue<Edge> _mst;
        private MinPQ<Edge> _pq;

        public Queue<Edge> Mst => _mst;

        public LazyPrimMST(EdgeWeightedGraph g)
        {
            _pq = new MinPQ<Edge>(g.V() * g.V() / 2);
            _marked = new bool[g.V()];
            _mst = new Queue<Edge>();

            Visit(g, 0);
            while (_pq.Count > 0)
            {
                Edge e = _pq.DelMin();

                int v = e.ThisVertex();
                int w = e.OtherVertex(v);
                if (_marked[v] && _marked[w]) continue;
                _mst.Enqueue(e);
                if (!_marked[v]) Visit(g, v);
                if (!_marked[w]) Visit(g, w);
            }

        }

        private void Visit(EdgeWeightedGraph g, int v)
        {
            _marked[v] = true;
            foreach (Edge e in g.Adj(v))
            {
                if (!_marked[e.OtherVertex(v)])
                {
                    _pq.Insert(e);
                }
            }
        }
    }
}