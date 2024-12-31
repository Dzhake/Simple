namespace Simple;

public static partial class Commands
{
    public static void Var(string arg)
    {
        string[] args = arg.Split(' ');
        if (args.Length <= 1) Guard.WrongArgsCount(2, args.Length);

        bool value = false;
        switch (args[1])
        {
            case "false":
                break;
            case "true":
                value = true;
                break;
            default:
                Guard.InvalidArgument(2);
                break;
        }

        Interpreter.Variables[args[0]] = value;
    }
}
