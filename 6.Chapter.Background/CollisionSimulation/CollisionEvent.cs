namespace CollisionSimulation
{
    public class CollisionEvent : System.IComparable<CollisionEvent>
    {
        private double _time;
        public double Time => _time;
        private Particle _a, _b;
        public Particle A => _a;
        public Particle B => _b;
        private int _countA, _countB;

        public CollisionEvent(double t, Particle a, Particle b)
        {
            _time = t;
            _a = a;
            _b = b;
            _countA = _a?.Count() ?? 0;
            _countB = _b?.Count() ?? 0;
        }
        public int CompareTo(CollisionEvent other)
        {
            return this._time.CompareTo(other._time);
        }
        public bool IsValid()
        {
            if (_a != null && _a.Count() != _countA) return false;
            if (_b != null && _b.Count() != _countB) return false;
            return true;
        }
    }
}