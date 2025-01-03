namespace Simple;

public static partial class Commands
{
    public static void Inv(string arg)
    {
        bool value = Stack.Pop();
        Stack.Push(!value);
    }
}
