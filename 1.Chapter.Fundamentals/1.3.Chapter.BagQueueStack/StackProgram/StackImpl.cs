using System;

namespace StackProgram
{
    /// <summary>
    /// 定容栈 —— 数组实现方式
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class StackImpl<TValue> : IStack<TValue>
    {
        private TValue[] _stack;
        private int _insertIndex = 0;
        public StackImpl(int size)
        {
            _stack = new TValue[size];
        }

        public bool IsEmpty()
        {
            return _insertIndex == 0;
        }

        public TValue Pop()
        {
            if (_insertIndex == 0) throw new IndexOutOfRangeException();
            TValue v = _stack[--_insertIndex];
            if (_insertIndex != 0 && _insertIndex <= _stack.Length / 4) Resize(_stack.Length / 2);
            return v;
        }

        public void Push(TValue value)
        {
            if (_insertIndex > _stack.Length - 1)
            {
                Resize(_stack.Length * 2);
            }
            _stack[_insertIndex++] = value;
        }

        public int Size()
        {
            return _insertIndex;
        }

        private void Resize(int size)
        {
            if (size < _stack.Length) throw new ArgumentException();
            TValue[] newStack = new TValue[size];
            for (int i = 0; i < _stack.Length; i++)
            {
                newStack[i] = _stack[i];
            }
            _stack = newStack;
        }
    }
}