using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex_1._3._31
{
    class Program
    {
        static void Main(string[] args)
        {
            ILinkList<int> list = new LinkList<int>();
            Enumerable.Range(0, 100).ToList().ForEach(e =>
            {
                list.InsertTail(e);
                if (e > 4 && e % 5 == 0)
                {
                    Console.WriteLine("delete head:{0}", list.DeleteHead());
                    Console.WriteLine("delete tail:{0}", list.DeleteTail());
                }
            });
            DoubleNode<int> root = list.Head;
            Console.WriteLine("===========遍历============");
            do
            {
                Console.WriteLine(root.Data);
                root = root.Next;
            } while (root != null);
            Console.WriteLine("delete head:{0}", list.DeleteHead());
            Console.WriteLine("delete tail:{0}", list.DeleteTail());
            Console.WriteLine("===========遍历============");

            root = list.Head;
            do
            {
                Console.WriteLine(root.Data);
                root = root.Next;
            } while (root != null);
        }
    }
}
