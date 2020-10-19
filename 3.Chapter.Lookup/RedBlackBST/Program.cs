using System;

namespace RedBlackBST
{
    class Program
    {
        static void Main(string[] args)
        {
            LLRedBlackTree<string,int> rbt = new LLRedBlackTree<string, int>();
            rbt.Put("S",1);
            rbt.Put("E",1);
            //rbt.Visualize();
            rbt.Put("A",1);
            rbt.Put("R",1);
            rbt.Put("B",1);
            rbt.Put("D",1);
            rbt.Put("C",1);
            rbt.Put("H",1);
            rbt.Put("X",1);
            rbt.Put("F",1);
            rbt.Put("M",1);
            rbt.Put("G",1);
            rbt.Put("J",1);
            rbt.Put("K",1);
            rbt.Put("P",1);
            rbt.Put("L",1);
            rbt.Delete("H");
            rbt.Delete("G");
            Console.WriteLine("Hello World!");
        }
    }
}
