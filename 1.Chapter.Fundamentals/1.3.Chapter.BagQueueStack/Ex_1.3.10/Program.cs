using System;
using System.Collections.Generic;

namespace Ex_1._3._10
{
    class Program
    {
        static int Priority(char op)
        {
            switch (op)
            {
                case '#':
                    return -1;
                case '(':
                    return 0;
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return -1;
            }
        }
        /// <summary>
        /// 中序表达式 转 后序表达式
        /// </summary>
        /// <param name="infix"></param>
        /// <returns></returns>
        static string InfixToPostfix(string infix){
            Stack<char> operationStack = new Stack<char>();
            operationStack.Push('#');
            Stack<char> dataStack = new Stack<char>();

            foreach (char ch in infix.ToCharArray())
            {
                switch (ch)
                {
                    case ')':
                        while ((true))
                        {
                            char c = operationStack.Pop();
                            if (c == '(') break;
                            dataStack.Push(c);
                        }
                        break;
                    case '(':
                        operationStack.Push(ch);
                        break;
                    case '+':
                    case '*':
                    case '-':
                    case '/':
                        if(Priority(ch) > Priority(operationStack.Peek())){
                            operationStack.Push(ch);
                        }else{
                            var op = operationStack.Pop();
                            while(Priority(ch) <= Priority(operationStack.Peek())){
                                dataStack.Push(operationStack.Pop());
                            }
                        }
                        break;
                    case '#':
                        break;
                    default:
                        dataStack.Push(ch);
                        break;
                }
            }
            string postfix = "";
            foreach (var s in dataStack)
            {
                postfix =  s + postfix;
            }
            return postfix;
        }
        static void Main(string[] args)
        {
            string infixText = "((((2+(4/2))+3)*4)+5)#";
            Console.WriteLine(InfixToPostfix(infixText));
        }
    }
}
