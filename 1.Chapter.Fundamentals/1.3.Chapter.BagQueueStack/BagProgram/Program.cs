using System;
using System.Linq;

namespace BagProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedBag<string> bag = new LinkedBag<string>();
            bag.Add("hi ");
            bag.Add(" how");
            bag.Add(" are");
            bag.Add(" u?");
            bag.ForEach(n => Console.WriteLine(n.data));
        }
    }
}
