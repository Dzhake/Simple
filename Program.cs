using System.IO;

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
            Interpreter.IntializeFunctions();
            Interpreter.ParseFile();
        }
    }
}
