using System;
using System.Linq;

namespace StackProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+===============LinkedStack============");

            IStack<int> linkedStack = new LinkedStack<int>();
            foreach(var i in Enumerable.Range(0,99999)){
                linkedStack.Push(i);
            }
            
            Console.WriteLine($"len:{linkedStack.Size()}");
            Console.WriteLine($"pop:{linkedStack.Pop()}");
            Console.WriteLine($"pop:{linkedStack.Pop()}");

            Console.WriteLine("+===============ArrayStack============");
            IStack<int> arrayStack = new ArrayStack<int>(40);
            foreach(var i in Enumerable.Range(100000,99999)){
                arrayStack.Push(i);
            }
            
            Console.WriteLine($"len:{arrayStack.Size()}");
            Console.WriteLine($"pop:{arrayStack.Pop()}");
            Console.WriteLine($"pop:{arrayStack.Pop()}");
        }
    }
}
