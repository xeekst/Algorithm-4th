using System;
using System.Collections;
using System.Collections.Generic;

namespace Ex_1._4._27
{
    class Program
    {
        class QueueFromStack<T>
        {
            public Stack<T> EnStack;
            public Stack<T> DeStack;

            public QueueFromStack(){
                EnStack = new Stack<T>();
                DeStack = new Stack<T>();
            }
            public void EnQueue(T value)
            {
                EnStack.Push(value);
            }
            public T DeQueue()
            {
                if (DeStack.Count == 0)
                {
                    while (EnStack.Count > 0)
                    {
                        DeStack.Push(EnStack.Pop());
                    }
                }
                return DeStack.Pop();
            }
            /** Get the front element. */
            public T Peek() {
                T last = DeQueue();
                DeStack.Push(last);
                return last;
            }
            
            /** Returns whether the queue is empty. */
            public bool Empty() {
                return EnStack.Count == 0 && DeStack.Count ==0;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
