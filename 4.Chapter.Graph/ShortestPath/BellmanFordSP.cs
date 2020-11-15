using System.Collections.Generic;

namespace ShortestPath
{
    //每次只relax distTo[] 发生变换的顶点
    public class BellmanFordSP
    {
        private double[] _distTo;
        private DirectedEdge[] _edgeTo;
        private bool[] _onQueue;
        // 主要就是这个队列。它会把经过负权的边重新处理
        private Queue<int> _queue;
        private int _cost;
        private Stack<DirectedEdge> _cycle;
        public BellmanFordSP(EdgeWeightedDigraph g, int s)
        {
            _distTo = new double[g.V];
            _edgeTo = new DirectedEdge[g.V];
            _onQueue = new bool[g.V];
            _queue = new Queue<int>();
            for (int i = 0; i < g.V; i++)
            {
                _distTo[i] = double.PositiveInfinity;
            }
            _distTo[s] = 0d;
            _queue.Enqueue(s);
            _onQueue[s] = true;
            while (_queue.Count > 0 && !HasNegativeCycle())
            {
                int v = _queue.Dequeue();
                _onQueue[v] = false;
                Relax(g, v);
            }
        }

        private void Relax(EdgeWeightedDigraph g, int v)
        {
            foreach (var e in g.Adj(v))
            {
                int w = e.To;
                if (_distTo[w] > _distTo[v] + e.Weight)
                {
                    _distTo[w] = _distTo[v] + e.Weight;
                    _edgeTo[w] = e;
                    if (!_onQueue[w])
                    {
                        _queue.Enqueue(w);
                        _onQueue[w] = true;
                    }
                }

                if (_cost++ % g.V == 0)
                {
                    FindNegativeCycle();
                }
            }
        }

        private void FindNegativeCycle()
        {
            int v = _edgeTo.Length;
            EdgeWeightedDigraph spt = new EdgeWeightedDigraph(v);
            for (int s = 0; s < v; s++)
            {
                if (_edgeTo[s] != null)
                {
                    spt.AddEdge(_edgeTo[s]);
                }
            }
            EdgeWeightedCycleFinder finder = new EdgeWeightedCycleFinder(spt);
            _cycle = finder.Cycle;
        }

        public bool HasNegativeCycle()
        {
            return _cycle != null;
        }
    }
}