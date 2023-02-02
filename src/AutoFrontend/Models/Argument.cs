using System;

namespace AutoFrontend.Models;

public sealed class Argument
{
    public string? Name { get; }
    public Definition Definition { get; }

    public Argument(string? name, Definition definition)
    {
        Name = name;
        Definition = definition;
    }
}
