using System.Collections.Generic;

namespace AutoFrontend.Models;

public sealed class Service
{
    public string Name { get; }
    public List<Function> Functions { get; } = new();

    public Service(string name)
    {
        Name = name;
    }
}
