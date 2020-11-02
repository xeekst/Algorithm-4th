using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace GraphBase
{
    public class Graph
    {
        private int _vertices;
        private int _edges;
        private IList<int> _dfsEdgeTos;
        private IList<int> _bfsEdgeTos;
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

        public bool HasPathTo(int v)
        {
            return false;
        }

        //广度优先搜索
        public void Bfs()
        {
            var marked = new bool[_vertices];
            Bfs(this, 0, marked);
        }

        private void Bfs(Graph g, int s, bool[] marked)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            marked[s] = true;
            while (queue.Count > 0)
            {
                var v = queue.Dequeue();
                foreach (var w in g._adjs[v])
                {
                    if (!marked[w])
                    {
                        //保存最先到达的点
                        _bfsEdgeTos[w] = v;
                        marked[w] = true;
                        queue.Enqueue(w);
                    }
                }
            }
        }

        //深度优先搜索
        public void Dfs()
        {
            var marked = new bool[_vertices];
            _dfsEdgeTos = new List<int>();
            int count = 0;
            Dfs(this, 0, marked, ref count);
        }

        private void Dfs(Graph g, int v, bool[] marked, ref int count)
        {
            marked[v] = true;
            count++;
            foreach (int w in g._adjs[v])
            {
                if (!marked[w])
                {
                    _dfsEdgeTos[w] = v;
                    Dfs(g, w, marked, ref count);
                }
            }
        }

        // 非递归深度优先遍历
        public void DfsNoRecursion(Graph g)
        {
            var marked = new bool[g.V()];
            var stack = new Stack<int>();
            stack.Push(0);

            Console.Write($"{stack.Peek()} ");
            while (stack.Count > 0)
            {
                int s = stack.Peek();
                marked[s] = true;
                int index = 0;
                foreach (int w in g.Adj(s))
                {
                    if (!marked[w])
                    {
                        stack.Push(w);

                        Console.Write($"{stack.Peek()} ");
                        break;
                    }

                    index++;
                }

                if (index == g.Adj(s).Count)
                {
                    stack.Pop();
                }
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