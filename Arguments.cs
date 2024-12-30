namespace Simple;

public static class Arguments
{
    public static void Parse(string[] args)
    {
        Program.FilePath = args[0];
    }
}
