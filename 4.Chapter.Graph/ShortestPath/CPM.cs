using System;
using System.Collections.Generic;

namespace ShortestPath
{
    public class CPM
    {
        public CPM(int N, List<string> edgeText)
        {
            var g = new EdgeWeightedDigraph(2 * N + 2);
            
            int s = 2 * N, t = 2 * N + 1;
            for (int i = 0; i < N; i++)
            {
                var e = edgeText[i].Split(' ');
                double duration = Convert.ToDouble(e[0]);
                g.AddEdge(new DirectedEdge(i, i + N, duration));
                g.AddEdge(new DirectedEdge(s, i, 0.0));
                g.AddEdge(new DirectedEdge(i + N, t, 0.0));
                for (int j = 1; j < e.Length; j++)
                {
                    int successor = Convert.ToInt32(e[j]);
                    g.AddEdge(new DirectedEdge(i + N, successor, 0.0));
                }
            }


            AcylicSP acy = new AcylicSP(g, s,AcylicSP.PathType.Lagrest);
            Console.WriteLine("start\ttimes");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"{i}\t{acy.DistTo[i]}");
            }
            Console.WriteLine($"Total Times:{acy.DistTo[t]}");
        }
    }
}