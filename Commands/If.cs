namespace Simple;

public static partial class Commands
{
    public static void If(string arg)
    {
        if (arg.Length == 0) Guard.WrongArgsCount(1, 0);

        string[] args = arg.Split(' ');

        bool jump = args.Length switch
        {
            1 => If1(args[0]),
            2 => If2(args[0], args[1]),
            3 => If3(args[0], args[1], args[2]),
            _ => false
        };

        if (jump) Interpreter.Line++;
    }

    private static bool If1(string arg)
    {
        return arg == "true";
    }

    private static bool If2(string arg1, string arg2)
    {
        switch (arg1)
        {
            case "!" or "not":
                return arg2 != "true";
            default:
                Guard.InvalidArgument(1);
                return false;
        }
    }

    private static bool If3(string arg1, string arg2, string arg3)
    {
        switch (arg2)
        {
            case "==":
                return arg1 == arg3;
            case "!=":
                return arg1 != arg2;
            default:
                Guard.InvalidArgument(2);
                return false;
        }
    }
}
