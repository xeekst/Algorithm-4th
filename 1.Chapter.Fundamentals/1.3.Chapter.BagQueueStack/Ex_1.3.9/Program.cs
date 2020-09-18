using System;
using System.Collections;
using System.Collections.Generic;

namespace Ex_1._3._9
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "2*3)-4)+6+5))";
            //"1+2)*3-4)*5-6)))";
            string fullStr = string.Empty;
            Stack<string> stack = new Stack<string>();
            foreach (var ch in s.ToCharArray())
            {
                string sch = ch.ToString();
                if (")".Contains(sch))
                {
                    var e1 = stack.Pop();
                    var e2 = stack.Pop();
                    var e3 = stack.Pop();
                    string ex = "(" + e3 + e2 + e1 + ")";
                    stack.Push(ex);
                }
                else
                {
                    stack.Push(sch);
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
