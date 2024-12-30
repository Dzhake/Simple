namespace Simple
{
    public static class Program
    {
        public static string? FilePath;

        public static void Main(string[] args)
        {
            if (args.Length == 0)
                Guard.Exception("Please input filename as first argument!");

            Arguments.Parse(args);
            Interpreter.Reset();
            new Interpreter(null).ParseFile(FilePath!);
        }
    }
}
