using System;

namespace StringsQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = "she sells seashells by the sea shore the shells she sells are surely seashells".Split(' ');
            var trieST = new TrieST<int>(256);
            for (int i = 0; i < a.Length; i++)
            {
                trieST.Put(a[i], i);
            }
            Console.WriteLine(trieST.GetValue("sea"));
        }
    }
}
