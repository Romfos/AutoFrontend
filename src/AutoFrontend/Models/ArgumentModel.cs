using System;

namespace AutoFrontend.Models;

public sealed class ArgumentModel(string name, Type type)
{
    public string Name { get; } = name;
    public Type Type { get; } = type;
}
