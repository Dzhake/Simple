﻿namespace Simple;

public static partial class Commands
{
    public static void Print(string _)
    {
        Console.Write(Stack.Pop());
    }
}
