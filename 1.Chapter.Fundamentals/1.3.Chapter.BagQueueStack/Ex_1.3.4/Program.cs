using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using StackProgram;

namespace Ex_1._3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = args.Length > 0 ? args[0] : "[()]{}{[()()]()}";
            IStack<string> stack = new LinkedStack<string>();
            foreach(var ch in text.ToCharArray()){
                string s = ch.ToString();
                if("[{(".Contains(s)){
                    stack.Push(s);
                }else if("}])".Contains(s)){
                    string left = stack.Pop();
                    if(!left.Equals(GetGoodLeft(s))){
                        Console.WriteLine("不匹配");
                        return;
                    }
                }else{
                    Console.WriteLine("不匹配");
                    return;
                }
            }
            if(stack.Size() != 0){
                Console.WriteLine("不匹配");
            }else{
                Console.WriteLine("匹配");
            }
            
        }
        public static string GetGoodLeft(string s)
        {
            switch (s)
            {
                case "]":
                    return "[";
                case ")":
                    return "(";
                case "}":
                    return "{";
                default:
                    throw new ArgumentException();

            }
        }
    }
}
