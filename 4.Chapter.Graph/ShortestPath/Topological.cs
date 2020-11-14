using System;
using System.Collections.Generic;

namespace ShortestPath
{
    //拓扑排序
    public class Topological
    {
        private IEnumerable<int> _order;
        
        public Topological(EdgeWeightedDigraph dg)
        {
            DepthFirstOrder dfo = new DepthFirstOrder(dg);
            _order = dfo.Reverse;
        }

        public IEnumerable<int> Order => _order;
    }
}
