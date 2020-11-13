using System;

namespace ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {

            EdgeWeightedDigraph g = new EdgeWeightedDigraph(8);
            g.AddEdge(new DirectedEdge(4, 5, 0.35));
            g.AddEdge(new DirectedEdge(5, 4, 0.35));
            g.AddEdge(new DirectedEdge(4, 7, 0.37));
            g.AddEdge(new DirectedEdge(5, 7, 0.28));
            g.AddEdge(new DirectedEdge(7, 5, 0.28));
            g.AddEdge(new DirectedEdge(5, 1, 0.32));
            g.AddEdge(new DirectedEdge(0, 4, 0.38));
            g.AddEdge(new DirectedEdge(0, 2, 0.26));
            g.AddEdge(new DirectedEdge(7, 3, 0.39));
            g.AddEdge(new DirectedEdge(1, 3, 0.29));
            g.AddEdge(new DirectedEdge(2, 7, 0.34));
            g.AddEdge(new DirectedEdge(6, 2, 0.40));
            g.AddEdge(new DirectedEdge(3, 6, 0.52));
            g.AddEdge(new DirectedEdge(6, 0, 0.58));
            g.AddEdge(new DirectedEdge(6, 4, 0.93));
            
            Console.WriteLine("Hello World!");
        }
    }
}
