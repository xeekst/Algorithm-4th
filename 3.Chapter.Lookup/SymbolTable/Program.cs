using System;

namespace SymbolTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayST<string,int> st = new ArrayST<string, int>(100);
            //BinarySearchST<string,int> st = new BinarySearchST<string, int>(100);
            //ZipperHashTableST<string,int> st = new ZipperHashTableST<string, int>(8);
            LinearProbingHashST<String,int> st = new LinearProbingHashST<string, int>(2);
            st.Put("A",1);
            Console.WriteLine(st.Get("A")?.Value);
            st.Put("B",2);
            st.Put("A",3);
            st.Put("C",1);
            st.Delete("A");
            st.Delete("gag");
        }
    }
}
