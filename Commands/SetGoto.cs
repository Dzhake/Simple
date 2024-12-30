namespace Simple;

public static partial class Commands
{
    public static void SetGoto(string args)
    {
        if (args.Length == 0) Guard.WrongArgsCount(1, 0);
        Interpreter.GotoPositions[args] = Interpreter.Current.Line;
    }
}
