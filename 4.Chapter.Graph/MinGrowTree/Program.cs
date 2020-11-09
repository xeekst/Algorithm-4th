using System;

namespace MinGrowTree
{
    class Program
    {
        static void Main(string[] args)
        {
            EdgeWeightedGraph g = new EdgeWeightedGraph(8);
            g.AddEdge(new Edge(0, 7, 16));
            g.AddEdge(new Edge(2, 3, 17));
            g.AddEdge(new Edge(1, 7, 19));
            g.AddEdge(new Edge(0, 2, 26));
            g.AddEdge(new Edge(5, 7, 28));
            g.AddEdge(new Edge(1, 3, 29));
            g.AddEdge(new Edge(1, 5, 32));
            g.AddEdge(new Edge(2, 7, 34));
            g.AddEdge(new Edge(4, 5, 35));
            g.AddEdge(new Edge(1, 2, 36));
            g.AddEdge(new Edge(4, 7, 37));
            g.AddEdge(new Edge(0, 4, 38));
            g.AddEdge(new Edge(6, 2, 40));
            g.AddEdge(new Edge(3, 6, 52));
            g.AddEdge(new Edge(6, 0, 58));
            g.AddEdge(new Edge(6, 4, 93));

            LazyPrimMST mst = new LazyPrimMST(g);

            foreach (Edge e in mst.Mst)
            {
                Console.Write($"{e} ");
            }

            KruskalMST kmst = new KruskalMST(g);
            Console.WriteLine("KruskalMST:");
            foreach (Edge e in kmst.MST)
            {
                Console.Write($"{e} ");
            }
        }
    }
}
