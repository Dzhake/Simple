namespace Simple;

public static partial class Commands
{
    public static void Goto(string arg)
    {
        if (arg.Length == 0) Guard.WrongArgsCount(1, 0);
        if (Interpreter.GotoPositions.TryGetValue(arg, out int newLine))
            Interpreter.JumpTo(newLine);
        else
            Guard.LabelNotFound(arg);
    }
}
