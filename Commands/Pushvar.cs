namespace Simple;

public static partial class Commands
{
    public static void PushVar(string arg)
    {
        if (arg.Length == 0) Guard.WrongArgsCount(1, 0);
        if (!Interpreter.Variables.TryGetValue(arg, out bool result))
            Guard.InvalidArgument(0);
        Stack.Push(result);
    }
}
