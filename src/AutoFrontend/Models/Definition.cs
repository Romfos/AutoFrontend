using System;

namespace AutoFrontend.Models;

public sealed class Definition
{
    public Type Type { get; }

    public Definition(Type type)
    {
        Type = type;
    }
}

