using System;

namespace StringsBase
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] a = new string[12] { "she", "bac", "abc", "src", "wuu", "bc", "fe", "ag", "agagag", "thyjhnf", "dsb", "s" };
            Quick3string.Sort(a);

            Console.WriteLine(string.Join(" ", a));
        }
    }
}
