using System;

namespace AutoFrontend.Models;

public sealed class ArgumentModel
{
    public string Name { get; }
    public Type Type { get; }

    public ArgumentModel(string name, Type type)
    {
        Name = name;
        Type = type;
    }
}
