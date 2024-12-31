namespace Simple;

public static class Guard
{
    /*Exit codes
     1 - General
     2 - Whilte interpreting.
     */
    public static void Exception(string exception, int code = 1)
    {
        Console.WriteLine($"ERROR: {exception}", ConsoleColor.Red);
        Environment.Exit(code);
    }

    public static void RuntimeException(string exception, int code = 2)
    {
        Exception($"{exception}\n  at line: {Interpreter.Current.Line}\n", code);
    }

    public static void GotoNotFound(string gotoName)
    {
        RuntimeException($"Goto {gotoName} not found!");
    }

    public static void WrongArgsCount(int expected, int got)
    {
        RuntimeException($"Excepted {expected} arguments, got {got}");
    }

    public static void InvalidArgument(int argumenIndex)
    {
        RuntimeException($"Invalid argument with index {argumenIndex}");
    }

    public static void UndefinedVariable(string variableName)
    {
        RuntimeException($"Tried to get undefined variable \'{variableName}\'");
    }
}
