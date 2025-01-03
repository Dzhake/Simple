namespace Simple;

public static partial class Commands
{
    public static void If(string arg)
    {
        bool goInside = Stack.Pop();
        if (!goInside) Interpreter.Line++;
    }
}
