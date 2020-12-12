using System;

namespace DataCompress
{
    class Program
    {
        static void Main(string[] args)
        {
            var bytes = HuffmanTrie.Compress("ABRACADABRA!");
            string str = HuffmanTrie.Expand(bytes);
            //HuffmanTrie.Compress("it was the best of times it was the worst of times !");
            Console.WriteLine("Hello World!");
        }
    }
}
