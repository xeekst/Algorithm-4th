using System;

namespace DataCompress
{
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanTrie.Compress("Hello World");
            Console.WriteLine("Hello World!");
        }
    }
}
