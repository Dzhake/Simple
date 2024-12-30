namespace Simple;

public static class Interpreter
{
    public static Dictionary<string, Action<string>> Functions = new(StringComparer.InvariantCultureIgnoreCase);
    public static void ParseFile()
    {
        string? filePath = Program.FilePath;
        if (filePath == null) Guard.Exception("FilePath is null, but ParseFile is called!");
        if (!File.Exists(filePath)) Guard.Exception("Specified file doesn't exist!");
        string[] lines = File.ReadAllLines(filePath!);
        foreach (string line in lines)
            ParseLine(line);
    }

    public static void IntializeFunctions()
    {
        Functions = new(StringComparer.InvariantCultureIgnoreCase)
        {
            { nameof(Commands.Print), Commands.Print }
        };
    }

    public static void ParseLine(string line)
    {
        if (line.StartsWith("//")) return;

        int funcLength = line.IndexOf(' ');
        string command = line[..funcLength];
        string args = line[(funcLength + 1)..];

        if (Functions.TryGetValue(command, out Action<string>? func))
            func(args);
    }
}
