namespace ShortestPath
{
    public class AcylicSP
    {
        private DirectedEdge[] _edgeTo;
        private double[] _distTo;

        private PathType _pathType;
        public enum PathType
        {
            Shortest,
            Lagrest
        }

        public AcylicSP(EdgeWeightedDigraph g, int s, PathType type)
        {
            _edgeTo = new DirectedEdge[g.V];
            _distTo = new double[g.V];
            _pathType = type;
            for (int v = 0; v < g.V; v++)
            {
                _distTo[v] = type == PathType.Lagrest ? double.NegativeInfinity : double.PositiveInfinity;
                _distTo[s] = 0.0;
            }

            Topological topol = new Topological(g);

            foreach (int v in topol.Order)
            {
                Relax(g, v);
            }
        }

        public double[] DistTo => _distTo;
        public void Relax(EdgeWeightedDigraph g, int v)
        {
            foreach (DirectedEdge e in g.Adj(v))
            {
                int w = e.To;
                switch (_pathType)
                {
                    case PathType.Lagrest:
                        if (_distTo[w] < _distTo[v] + e.Weight)
                        {
                            _distTo[w] = _distTo[v] + e.Weight;
                            _edgeTo[w] = e;
                        }
                        break;
                    case PathType.Shortest:
                        if (_distTo[w] > _distTo[v] + e.Weight)
                        {
                            _distTo[w] = _distTo[v] + e.Weight;
                            _edgeTo[w] = e;
                        }
                        break;
                }

            }
        }
    }
}