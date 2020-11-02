using System;

namespace DigraphBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Digraph g = new Digraph(9);
            //g.Visualize()
            g.AddEdge(0, 2);
            g.AddEdge(0, 6);
            g.AddEdge(1, 0);
            g.AddEdge(2, 3);
            g.AddEdge(2, 4);
            g.AddEdge(3, 4);
            g.AddEdge(3, 2);
            g.AddEdge(4, 5);
            g.AddEdge(4, 6);
            g.AddEdge(5, 0);
            g.AddEdge(5, 3);
            g.AddEdge(6, 7);
            g.AddEdge(7, 8);
            g.AddEdge(8, 7);

            var topo = new Topological(g);

            foreach (int s in topo.Order)
            {
                Console.Write(s + " ");
            }
        }
    }
}
