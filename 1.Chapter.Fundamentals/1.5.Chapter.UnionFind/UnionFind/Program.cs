using System;
using System.Diagnostics;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            string r = string.Empty;
            int n = int.Parse(Console.ReadLine());
            Stopwatch sw = new Stopwatch();
            sw.Start();
            PathCompressWeightedUnionFind pcwUF = new PathCompressWeightedUnionFind(n);
            while (!string.IsNullOrEmpty(r = Console.ReadLine()))
            {
                string[] pairs = r.Split(' ');
                int p = int.Parse(pairs[0]);
                int q = int.Parse(pairs[1]);
                pcwUF.Union(p, q);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            Console.WriteLine(pcwUF.Count);
            Console.WriteLine(pcwUF.Connected(3, 4));
            Console.WriteLine(pcwUF.Connected(14, 42));
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            // QuickUnion qkUF = new QuickUnion(n);
            // while (!string.IsNullOrEmpty(r = Console.ReadLine()))
            // {
            //     string[] pairs = r.Split(' ');
            //     int p = int.Parse(pairs[0]);
            //     int q = int.Parse(pairs[1]);
            //     qkUF.Union(p, q);
            // }
            // sw.Stop();
            // Console.WriteLine(sw.ElapsedMilliseconds);
            // sw.Restart();
            // Console.WriteLine(qkUF.Count);
            // Console.WriteLine(qkUF.Connected(3, 4));
            // Console.WriteLine(qkUF.Connected(14, 42));
            // sw.Stop();
            // Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
