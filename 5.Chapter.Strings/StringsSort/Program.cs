using System;

namespace StringsSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = new string[12] { "she", "bac", "abc", "src", "wuu", "bc", "fe", "ag", "agagag", "thyjhnf", "dsb", "s" };
            string[] a3 = "she sells seashells by the sea shore the shells she sells are surely seashells".Split(' ');
            Quick3string.Sort(a);

            Console.WriteLine("Quick3String:{0}", string.Join(" ", a));

            string[] a2 = @"bed bug dad yes zoo now for tip ilk dim tag jot sob nob sky hut men egg few jay owl joy rap gig wee was wad fee tap tar dug jam all bad yet".Split(' ');
            LSD.Sort(a2, 3, 256);
            Console.WriteLine("LSD:{0}", string.Join(" ", a2));

            MSD.Sort(a3, 256);
            Console.WriteLine("MSD:{0}", string.Join(" ", a3));
        }
    }
}
