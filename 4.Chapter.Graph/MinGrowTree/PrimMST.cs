using System.Collections.Generic;

namespace MinGrowTree
{
    public class PrimMST
    {
        // 距离最小生成树最近的边 即： _edgeTo[2] 即2连接到最小生成树当前最小的边
        private Edge[] _edgeTo;
        // 当前连接到最小生成树的顶点之边的权重 即：_distTo[2] 当前2连接到最小生成树到最小的权重
        private double[] _distTo;
        private bool[] _marked;
        private IndexMinPQ<double> _pq;
        public int w { get; set; }
        public Queue<Edge> MST
        {
            get
            {
                var q = new Queue<Edge>();
                for (int i = 1; i < _edgeTo.Length; i++)
                {
                    q.Enqueue(_edgeTo[i]);
                }
                return q;
            }
        }
        public PrimMST(EdgeWeightedGraph g)
        {
            _edgeTo = new Edge[g.V()];
            _distTo = new double[g.V()];
            _marked = new bool[g.V()];

            for (int v = 0; v < g.V(); v++)
            {
                _distTo[v] = double.PositiveInfinity;
            }

            _pq = new IndexMinPQ<double>(g.V());
            _distTo[0] = 0;
            _pq.Insert(0, 0.0);
            while (_pq.Count > 0)
            {
                Visit(g, _pq.DelMin());
            }
        }

        private void Visit(EdgeWeightedGraph g, int v)
        {
            _marked[v] = true;
            foreach (Edge e in g.Adj(v))
            {
                int w = e.OtherVertex(v);
                if (_marked[w]) continue;
                //每次只记录最小的那条边 有更小的便更新它
                if (e.Weight < _distTo[w])
                {
                    //更新某一点w连接最小生成树的边
                    _edgeTo[w] = e;
                    //更新或插入最小堆
                    if (_pq.Contains(w))
                    {
                        _pq.Change(w, e.Weight);
                    }
                    else
                    {
                        _pq.Insert(w, e.Weight);
                    }
                    _distTo[w] = e.Weight;
                }
            }
        }

    }
}