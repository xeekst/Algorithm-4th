using System;

namespace SuffixArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "it was the best of times it was the worst of times";
            Console.WriteLine(LRS.GetLongestSubString(text));
            Console.WriteLine(KWIC.GetContexts(text,"was",2));
        }
    }
}
