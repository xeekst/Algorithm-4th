using System;

namespace DigraphBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Digraph g = new Digraph(7);
            //g.Visualize()
            g.AddEdge(0,1);
            g.AddEdge(0,2);
            g.AddEdge(0,5);
            g.AddEdge(0,6);
            g.AddEdge(5,4);
            g.AddEdge(3,4);
            g.AddEdge(6,4);
            g.AddEdge(5,3);
            Console.Write(0);
        }
    }
}
