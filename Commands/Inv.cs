namespace Simple;

public static partial class Commands
{
    public static void Inv(string arg)
    {
        if (!Interpreter.Variables.TryGetValue(arg, out bool value))
            Guard.UndefinedVariable(arg);
        Interpreter.Variables[arg] = !value;
    }
}
