using System;

namespace AutoFrontend.Models;

public sealed class Argument
{
    public string? Name { get; }
    public Type AwaitResultType { get; }
    public bool IsTask { get; }
    public bool IsValueTask { get; }

    public Argument(string? name, Type awaitResultType, bool isTask, bool isValueTask)
    {
        Name = name;
        AwaitResultType = awaitResultType;
        IsTask = isTask;
        IsValueTask = isValueTask;
    }
}
