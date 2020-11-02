using System;
using System.Collections.Generic;

namespace DigraphBase
{
    public class DepthFirstOrder
    {
        private bool[] marked;
        private Queue<int> preQueue;
        private Queue<int> postQueue;
        private Stack<int> reversePost;

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

        private void Dfs(Digraph digraph, int v)
        {
            preQueue.Enqueue(v);
            foreach (int w in digraph.Adj(v))
            {
                if (!marked[w])
                {
                    Dfs(digraph, v);
                }
            }
            postQueue.Enqueue(v);
            reversePost.Push(v);
        }
    }
}
