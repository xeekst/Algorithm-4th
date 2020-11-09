using System.Collections.Generic;

namespace MinGrowTree
{
    public class KruskalMST
    {
        private Queue<Edge> _mst;
        private PathCompressWeightedUnionFind _uf;
        //边权重的最小队列
        private MinPQ<Edge> _pq;
        public Queue<Edge> MST => _mst;
        public KruskalMST(EdgeWeightedGraph g)
        {
            _uf = new PathCompressWeightedUnionFind(g.V());
            _pq = new MinPQ<Edge>(g.V() * g.V());
            _mst = new Queue<Edge>();
            foreach (var e in g.Edges())
            {
                _pq.Insert(e);
            }
            while (_pq.Count > 0 && _mst.Count < g.V() - 1)
            {
                Edge e = _pq.DelMin();
                int v = e.ThisVertex();
                int w = e.OtherVertex(v);
                if (_uf.Connected(v, w)) continue;
                _mst.Enqueue(e);
                _uf.Union(v, w);
            }
        }
    }
}