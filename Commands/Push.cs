namespace Simple;

public static partial class Commands
{
    public static void Push(string arg)
    {
        if (arg.Length == 0) Guard.WrongArgsCount(1, 0);
        if (!bool.TryParse(arg, out bool result))
            Guard.InvalidBool(arg);
        Stack.Push(result);
    }
}
