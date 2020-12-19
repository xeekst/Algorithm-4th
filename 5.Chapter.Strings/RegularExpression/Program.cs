using System;

namespace RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            NFA nfa = new NFA("((A*B|AC)D)");
            var grep = new Grep();
            Console.WriteLine(grep.Recognizes("((A*B|AC)D)","AAAAABD"));
            Console.WriteLine("Hello World!");
        }
    }
}
