using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace GraphBase
{
    public class Graph
    {
        private int _vertices;
        private int _edges;
        private HashSet<int>[] _adjs;

        //V表示定点数量
        public Graph(int V)
        {
            _vertices = V;
            _adjs = new HashSet<int>[V];
            for (int i = 0; i < _adjs.Length; i++)
            {
                _adjs[i] = new HashSet<int>();
            }
        }
        //返回顶点数
        public int V()
        {
            return _vertices;
        }

        //返回边数
        public int E()
        {
            return _edges;
        }

        public void AddEdge(int v, int w)
        {
            _adjs[v].Add(w);
            _adjs[w].Add(v);
            _edges++;
        }

        public HashSet<int> Adj(int v)
        {
            return _adjs[v];
        }

        public void Dfs()
        {
            var marked = new bool[_vertices];
            int count = 0;
            Dfs(this, 0, marked, ref count);
        }

        private void Dfs(Graph g, int v, bool[] marked, ref int count)
        {
            marked[v] = true;
            count++;
            foreach (int w in g._adjs[v])
            {
                if (!marked[w]) Dfs(g, w, marked, ref count);
            }
        }

        public string Visualize()
        {
            GraphVisualizer vis = new GraphVisualizer();
            for (int i = 0; i < _adjs.Length; i++)
            {
                var node = new GraphVisualizer.Node();
                node.label = i.ToString();
                node.id = i.ToString();
                vis.nodes.Add(node);
                for (int j = 0; j < _adjs[i].Count; j++)
                {
                    var e = new GraphVisualizer.Edge()
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