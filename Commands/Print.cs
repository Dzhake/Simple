namespace Simple;

public static partial class Commands
{
    public static void Print(string args)
    {
        if (args.Length == 0) Guard.Exception("Expected more than 0 arguments!", 2);
        Console.Write(args);
    }
}
