using System;

namespace CollisionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 100;
            Particle[] particles = new Particle[N];
            for (int i = 0; i < N; i++)
            {
                particles[i] = new Particle();
            }
            CollisionSystem system = new CollisionSystem(particles);
            system.Simulate(10000, 0.5);
        }
    }
}
