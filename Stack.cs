namespace Simple;

public static class Stack
{

    public static void Push(bool value)
    {
        Interpreter.Stack.Push(value);
    }


    public static bool Pop()
    {
        if (Interpreter.Stack.Count == 0)
            Guard.EmptyStack();

        return Interpreter.Stack.Pop();
    }

    public static bool TryPop(out bool value)
    {
        value = false;
        if (Interpreter.Stack.Count == 0)
            return false;
        value = Interpreter.Stack.Pop();
        return true;
    }

    public static bool Peek()
    {
        if (Interpreter.Stack.Count == 0)
            Guard.EmptyStack();

        return Interpreter.Stack.Peek();
    }
}
