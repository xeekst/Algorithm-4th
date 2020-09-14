using System;
using System.Collections.Generic;

namespace Ex_1._1._27
{
    class Program
    {
        static int binomialCount = 0;
        static Dictionary<string,double> binomialDict = new Dictionary<string,double>() ;
        /// <summary>
        /// 1.1.27 二项分布
        /// </summary>
        /// <param name="N"></param>
        /// <param name="k"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        static double binomial(int N, int k, double p)
        {
            binomialCount++;
            if (N == 0 && k == 0) return 1.0;
            if (N < 0 || k < 0) return 0.0;
            string key1 = $"{N-1}-{k}-{p}";
            string key2 = $"{N-1}-{k-1}-{p}";
            var r1 = binomialDict.ContainsKey(key1) ? binomialDict[key1] : binomial(N - 1, k, p);
            var r2 = binomialDict.ContainsKey(key2) ? binomialDict[key2] : binomial(N - 1, k - 1, p);
            binomialDict[key1] = r1;
            binomialDict[key2] = r2;
            return (1.0 - p) * r1 + p * r2;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"binomial:{binomial(100, 50, 0.25)}");
            Console.WriteLine($"invoke binomial count:{binomialCount++}");
        }
    }
}
