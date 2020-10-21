using System;

namespace RedBlackBST
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            LLRedBlackTree<int, int> llrbt = new LLRedBlackTree<int, int>();
            for (int i = 0; i < Math.Pow(10, 2); i++)
            {
                var k = rnd.Next(1, 1000000);
                llrbt.Put(k, 1);
            }
            llrbt.Delete(1314);


            LLRedBlackTree<string, int> rbt = new LLRedBlackTree<string, int>();
            rbt.Put("S", 1);
            rbt.Put("E", 1);
            //rbt.Visualize();
            rbt.Put("A", 1);
            rbt.Put("R", 1);
            rbt.Put("B", 1);
            rbt.Put("D", 1);
            rbt.Put("C", 1);
            rbt.Put("H", 1);
            rbt.Put("X", 1);
            rbt.Put("F", 1);
            rbt.Put("M", 1);
            rbt.Put("G", 1);
            rbt.Put("J", 1);
            rbt.Put("K", 1);
            rbt.Put("P", 1);
            rbt.Put("L", 1);
            rbt.Delete("H");
            rbt.Delete("G");
            Console.WriteLine("Hello World!");
        }

        static void Test()
        {
            
        }
    }
}
