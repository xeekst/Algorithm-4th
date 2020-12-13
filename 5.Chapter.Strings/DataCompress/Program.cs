using System;

namespace DataCompress
{
    class Program
    {
        static void Main(string[] args)
        {
            BitVirtualSteam bvStream = new BitVirtualSteam();
            // 12 bit (0,4096)
            bvStream.Write(4095, 12);
            int v = bvStream.ReadInt(12);

            var bytes = HuffmanTrie.Compress("ABRACADABRA!");
            string str = HuffmanTrie.Expand(bytes);
            //HuffmanTrie.Compress("it was the best of times it was the worst of times !");
            byte[] lzwBytes = LZW.Compress("ABRACADABRABRABRA");
            string lzwText = LZW.Expand(lzwBytes);
            Console.WriteLine("Hello World!");
        }
    }
}
