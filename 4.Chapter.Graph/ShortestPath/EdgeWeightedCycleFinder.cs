using System.Collections.Generic;

namespace ShortestPath
{
    public class EdgeWeightedCycleFinder
    {
        private bool[] _marked;
        private DirectedEdge[] _edgeTo;
        private Stack<DirectedEdge> _cycle;
        private bool[] _onStack;

        public EdgeWeightedCycleFinder(EdgeWeightedDigraph g)
        {
            _onStack = new bool[g.V];
            _edgeTo = new DirectedEdge[g.V];
            _marked = new bool[g.V];
            for (int v = 0; v < g.V; v++)
            {
                if (!_marked[v]) Dfs(g, v);
            }
        }

        public Stack<DirectedEdge> Cycle => _cycle;

        //若 顶点v在一个环中，那么一次深搜可以找到该环
        private void Dfs(EdgeWeightedDigraph g, int v)
        {
            _onStack[v] = true;
            _marked[v] = true;
            foreach (var e in g.Adj(v))
            {
                if (HasCycle()) return;
                else if (!_marked[e.To])
                {
                    _edgeTo[e.To] = e;
                    Dfs(g, e.To);
                }
                //如果遍历到一个已经访问过到点，那么就是有环了
                else if (_onStack[e.To])
                {
                    _cycle = new Stack<DirectedEdge>();
                    var f = e;
                    while (f.From != e.To)
                    {
                        _cycle.Push(f);
                        f = _edgeTo[f.From];
                    }
                    _cycle.Push(f);
                }
            }
            _onStack[v] = false;
        }

        private bool HasCycle()
        {
            return _cycle != null;
        }
    }
}