namespace CollisionSimulation
{
    public class CollisionSystem
    {
        private MinPQ<CollisionEvent> _pq;
        private double t = 0d;
        private Particle[] _particles;
        public CollisionSystem(Particle[] particles)
        {
            this._particles = particles;
            _pq = new MinPQ<CollisionEvent>(1000);
        }

        public void ReDraw(double limit, double Hz)
        {
            for (int i = 0; i < _particles.Length; i++)
                _particles[i].Draw();
            if (t < limit)
            {
                _pq.Insert(new CollisionEvent(t + 1.0 / Hz, null, null));
            }
        }

        private void PredictCollisions(Particle a, double limit)
        {
            if (a == null) return;
            for (int i = 0; i < _particles.Length; i++)
            {
                double dt = a.TimeToHit(_particles[i]);
                if (t + dt < limit)
                {
                    _pq.Insert(new CollisionEvent(t + dt, a, _particles[i]));
                }
            }
            double dtX = a.TimeToHitVerticalWall();
            if (t + dtX <= limit)
            {
                _pq.Insert(new CollisionEvent(t + dtX, a, null));
            }
            double dtY = a.TimeToHItHorizontalWall();
            if (t + dtY < limit)
            {
                _pq.Insert(new CollisionEvent(t + dtY, null, a));
            }
        }

        public void Simulate(double limit, double Hz)
        {
            _pq = new MinPQ<CollisionEvent>(1000);
            for (int i = 0; i < _particles.Length; i++)
            {
                PredictCollisions(_particles[i], limit);
            }
            _pq.Insert(new CollisionEvent(0, null, null));
            while (_pq.Count > 0)
            {
                CollisionEvent collisionEvent = _pq.DelMin();
                if (!collisionEvent.IsValid()) continue;
                for (int i = 0; i < _particles.Length; i++)
                {
                    _particles[i].Move(collisionEvent.Time - t);
                }
                t = collisionEvent.Time;
                Particle a = collisionEvent.A, b = collisionEvent.B;
                if (a != null && b != null) a.BounceOff(b);
                else if (a != null && b == null) a.BounceOffVerticalWall();
                else if (a == null && b != null) b.BounceOffHorizontalWall();
                else if (a == null && b == null) ReDraw(limit, Hz);
                PredictCollisions(a, limit);
                PredictCollisions(b, limit);
            }
        }
    }
}