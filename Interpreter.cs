using System.Reflection;
using System.Text.RegularExpressions;

namespace Simple;

public static class Interpreter
{
    public static Dictionary<string, Action<string>> Functions;
    public static Dictionary<string, int> GotoPositions;
    public static Dictionary<string, bool> Variables;
    private static readonly string[] IgnoredMethodNames = ["GetType", "ToString", "Equals", "GetHashCode"];

    private static Regex VarRegex = new("{(.*?)}", RegexOptions.Compiled);

    public static int Line;

    static Interpreter()
    {
        Reset();
    }

    public static void ParseFile(string file)
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

    

    public static void ParseLine(string line)
    {
        if (line.StartsWith("//")) return;

        foreach (Match match in VarRegex.Matches(line))
        {
            string varName = match.Groups[1].Value;
            if (Variables.TryGetValue(varName, out bool var))
                line = line.Replace(match.Value, var.ToString());
            else
                Guard.UndefinedVariable(varName);
        }
            

        int funcLength = line.IndexOf(' ');

        string command;
        string args = "";
        if (funcLength <= 0)
            command = line;
        else
        {
            command = line[..funcLength];
            args = line[(funcLength + 1)..];
        }

        if (Functions.TryGetValue(command, out Action<string>? func))
            func(args);
    }

    public static void Reset()
    {
        IntializeFunctions();
        GotoPositions = new(StringComparer.InvariantCultureIgnoreCase);
        Variables = new(StringComparer.InvariantCultureIgnoreCase);
    }

    private static void IntializeFunctions()
    {
        Functions = new(StringComparer.InvariantCultureIgnoreCase);

        foreach (MethodInfo method in typeof(Commands).GetMethods())
        {
            if (!method.IsPublic || IgnoredMethodNames.Contains(method.Name)) continue;
            object o;
            Functions.Add(method.Name, method.CreateDelegate<Action<string>>());
        }
    }

    public static void JumpTo(int line)
    {
        Line = line - 1;
    }
}
