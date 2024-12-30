namespace Simple;

public class Interpreter
{
    public static Interpreter Current = new(null);
    public static Dictionary<string, Action<string>> Functions = new();
    public static Dictionary<string, int> GotoPositions = new();
    public Interpreter? Parent;

    
    public int Line { get; protected set; }

    public Interpreter(Interpreter? parent)
    {
        Current = this;
        Parent = parent;
    }

    public void ParseFile(string file)
    {
        if (!File.Exists(file)) Guard.Exception("Specified file doesn't exist!");
        string[] lines = File.ReadAllLines(file);

        Line = 0;
        while (Line < lines.Length)
        {
            ParseLine(lines[Line]);
            Line++;
        }
    }

    

    public void ParseLine(string line)
    {
        if (line.StartsWith("//")) return;

        int funcLength = line.IndexOf(' ');
        string command = line[..funcLength];
        string args = line[(funcLength + 1)..];

        if (Functions.TryGetValue(command, out Action<string>? func))
            func(args);
    }

    public static void Reset()
    {
        IntializeFunctions();
        GotoPositions = new(StringComparer.InvariantCultureIgnoreCase);
    }

    protected static void IntializeFunctions()
    {
        Functions = new(StringComparer.InvariantCultureIgnoreCase)
        {
            { nameof(Commands.Print), Commands.Print }
        };
    }

    public static void JumpTo(int line)
    {
        Current.Line = line - 1;
    }
}
