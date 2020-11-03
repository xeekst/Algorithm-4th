using System;
using System.Collections.Generic;
using System.Linq;

namespace DigraphBase
{
    //顶点遍历方式
    public class DepthFirstOrder
    {
        private bool[] marked;
        private Queue<int> preQueue;
        private Queue<int> postQueue;
        private Stack<int> reversePost;

        public IEnumerable<int> Pre => preQueue.ToList();
        public IEnumerable<int> Post => postQueue.ToList();
        public IEnumerable<int> Reverse => reversePost.ToList();

        public DepthFirstOrder(Digraph dg)
        {
            preQueue = new Queue<int>();
            postQueue = new Queue<int>();
            reversePost = new Stack<int>();
            marked = new bool[dg.V()];
            for (int s = 0; s < dg.V(); s++)
            {
                if (!marked[s])
                {
                    Dfs(dg, s);
                }
            }
        }

        private void Dfs(Digraph dg, int v)
        {
            preQueue.Enqueue(v);
            marked[v] = true;

            foreach (int w in dg.Adj(v))
            {
                if (!marked[w])
                {
                    Dfs(dg, w);
                }
            }

            postQueue.Enqueue(v);
            reversePost.Push(v);
        }
    }
}
