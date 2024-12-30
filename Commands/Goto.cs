namespace Simple;

public static partial class Commands
{
    public static void Goto(string args)
    {
        if (args.Length == 0) Guard.WrongArgsCount(1, 0);
        if (Interpreter.GotoPositions.TryGetValue(args, out int newLine))
            Interpreter.JumpTo(newLine);
        else
            Guard.GotoNotFound(args);
    }
}
