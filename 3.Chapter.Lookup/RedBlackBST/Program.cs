using System;

namespace RedBlackBST
{
    class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree<string,int> rbt = new RedBlackTree<string, int>();
            rbt.Put("S",1);
            rbt.Put("E",1);
            rbt.Visualize();
            rbt.Put("A",1);
            rbt.Put("R",1);
            rbt.Put("C",1);
            rbt.Put("H",1);
            rbt.Put("X",1);
            rbt.Put("M",1);
            rbt.Put("P",1);
            rbt.Put("L",1);
            Console.WriteLine("Hello World!");
        }
    }
}
