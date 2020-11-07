namespace DigraphBase
{
    public class TransitiveClosure
    {
        private DirectedDFS[] _all;

        public TransitiveClosure(Digraph g)
        {
            _all = new DirectedDFS[g.V()];
            for (int s = 0; s < g.V(); s++)
            {
                _all[s] = new DirectedDFS(g, s);
            }
        }

        public bool Reachable(int v, int w)
        {
            return _all[v].Reachable(w);
        }
    }
}