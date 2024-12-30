namespace Simple;

public static class Guard
{
    public static void Exception(string exception, int code = 1)
    {
        Console.WriteLine($"ERROR: {exception}");
        Environment.Exit(code);
    }
}
