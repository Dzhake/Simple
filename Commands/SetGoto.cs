namespace Simple;

public static partial class Commands
{
    public static void SetGoto(string arg)
    {
        if (arg.Length == 0) Guard.WrongArgsCount(1, 0);
        Interpreter.GotoPositions[arg] = Interpreter.Line;
    }
}
