using System;

namespace AutoFrontend.Models;

public sealed class Argument
{
    public string? Name { get; }
    public Type ArgumentType { get; }
    public bool IsResult { get; }
    public bool IsTask { get; }
    public bool IsValueTask { get; }

    public Argument(string? name, Type argumentType, bool isResult, bool isTask, bool isValueTask)
    {
        Name = name;
        ArgumentType = argumentType;
        IsResult = isResult;
        IsTask = isTask;
        IsValueTask = isValueTask;
    }
}
