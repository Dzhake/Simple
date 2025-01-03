namespace Simple;

public static class Guard
{
    /*Exit codes
     0 - EOF/Exit command
     1 - General
     2 - While interpreting.
     */
    public static void Exception(string exception, int code = 1)
    {
        Console.WriteLine($"ERROR: {exception}", ConsoleColor.Red);
        Environment.Exit(code);
    }

    public static void RuntimeException(string exception, int code = 2)
    {
        Exception($"{exception}\n  at line: {Interpreter.Line}\n> {Interpreter.Lines[Interpreter.Line]}", code);
    }

    public static void LabelNotFound(string gotoName)
    {
        RuntimeException($"Label {gotoName} not found");
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

    public static void EmptyStack()
    {
        RuntimeException("Tried to get value from empty stack");
    }

    public static void InvalidBool(string boolean)
    {
        RuntimeException($"Tried to parse invalid string as bool: {boolean}");
    }
}
