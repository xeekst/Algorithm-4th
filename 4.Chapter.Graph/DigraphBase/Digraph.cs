using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DigraphBase
{
    public class Digraph
    {
        private int _vertices;
        private int _edges;
        private HashSet<int>[] _adjs;

        public Digraph(int v)
        {
            _vertices = v;
            _adjs = new HashSet<int>[v];
            for (int i = 0; i < v; i++)
            {
                _adjs[i] = new HashSet<int>();
            }

        }

        public void AddEdge(int v, int w)
        {
            _adjs[v].Add(w);
            _edges++;
        }

        public Digraph Reverse()
        {
            Digraph d = new Digraph(_vertices);
            for (int v = 0; v < _adjs.Length; v++)
            {
                foreach (int w in _adjs[v])
                {
                    d.AddEdge(w, v);
                }
            }
            return d;
        }

        public HashSet<int> Adj(int v)
        {
            return _adjs[v];
        }

        public int V()
        {
            return _vertices;
        }

        public string Visualize()
        {
            DigraphVisualizer vis = new DigraphVisualizer();
            for (int i = 0; i < _adjs.Length; i++)
            {
                var node = new DigraphVisualizer.Node();
                node.label = i.ToString();
                node.id = i.ToString();
                vis.nodes.Add(node);
                for (int j = 0; j < _adjs[i].Count; j++)
                {
                    var e = new DigraphVisualizer.Edge()
                    {
                        from = i.ToString(),
                        to = _adjs[i].ToList()[j].ToString()
                    };
                    vis.edges.Add(e);
                }
            }
            return JsonConvert.SerializeObject(vis);
        }
    }
}
