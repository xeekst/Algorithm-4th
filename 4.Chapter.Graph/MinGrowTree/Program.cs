using System;
using System.Collections.Generic;
using System.Linq;

namespace MinGrowTree
{
    class Program
    {
        static void Main(string[] args)
        {

            // IndexMinPQ<int> imPQ = new IndexMinPQ<int>(10);
            // var list = new List<int>() { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // for (int i = 0; i < list.Count; i++)
            // {
            //     imPQ.Insert(i, list[i]);
            // }
            // foreach (int i in Enumerable.Range(1, 10))
            // {
            //     int k = imPQ.DelMin();
            //     Console.WriteLine(k);
            // }

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
            Console.WriteLine("LazyPrimMST:");
            foreach (Edge e in mst.Mst)
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();

            KruskalMST kmst = new KruskalMST(g);
            Console.WriteLine("KruskalMST:");
            foreach (Edge e in kmst.MST)
            {
                Console.Write($"{e} ");
            }

            Console.WriteLine();
            PrimMST pmst = new PrimMST(g);
            Console.WriteLine("PrimMST:");
            foreach (Edge e in pmst.MST)
            {
                Console.Write($"{e} ");
            }
        }
    }
}
