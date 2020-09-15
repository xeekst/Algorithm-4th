namespace StackProgram
{
    public interface IStack<TValue>
    {
        void Push(TValue value);

        TValue Pop();

        int Size();

        bool IsEmpty();
    }
}