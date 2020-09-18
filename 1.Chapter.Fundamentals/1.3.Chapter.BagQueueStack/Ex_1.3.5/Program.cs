using System;
using StackProgram;

namespace Ex_1._3._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = args.Length > 0 ? int.Parse(args[0]) : 50;
            IStack<int> stack = new LinkedStack<int>();
            while(n > 0){
                stack.Push( n % 2);
                n = n / 2;
            }
            string s = "";
            while(stack.Size() > 0){
                s = s + stack.Pop();
            }
            Console.WriteLine(s);
        }
    }
}
