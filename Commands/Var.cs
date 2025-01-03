﻿namespace Simple;

public static partial class Commands
{
    public static void Var(string arg)
    {
        if (arg.Length <= 1) Guard.WrongArgsCount(1, 0);

        Interpreter.Variables[arg] = Stack.Pop();
    }
}
