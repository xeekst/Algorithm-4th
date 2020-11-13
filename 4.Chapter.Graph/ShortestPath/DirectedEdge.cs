namespace ShortestPath
{
    public class DirectedEdge
    {
        private int _v;
        private int _w;
        private double _weight;
        public DirectedEdge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            _weight = weight;
        }

        public double Weight => _weight;

        public int From => _v;
        public int To => _w;

        public override string ToString()
        {
            return $"{_v}->{_w} {_weight}";
        }
    }
}