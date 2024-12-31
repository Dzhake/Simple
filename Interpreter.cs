using System.Text.RegularExpressions;

namespace Simple;

public class Interpreter
{
    public static Interpreter Current = new(null);
    public static Dictionary<string, Action<string>> Functions;
    public static Dictionary<string, int> GotoPositions;
    public static Dictionary<string, bool> Variables;
    public Interpreter? Parent;

    protected Regex VarRegex = new("{(.*?)}", RegexOptions.Compiled);
    
    public int Line { get; protected set; }

    static Interpreter()
    {
        Reset();
    }

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

        foreach (Match match in VarRegex.Matches(line))
        {
            string varName = match.Groups[0].Value;
            if (Variables.TryGetValue(varName, out bool var))
                line = line.Replace(match.Value, var.ToString());
            else
                Guard.UndefinedVariable(varName);
        }
            

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
        Variables = new(StringComparer.InvariantCultureIgnoreCase);
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
