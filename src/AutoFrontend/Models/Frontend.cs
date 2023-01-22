using System.Collections.Generic;

namespace AutoFrontend.Models;

public sealed class Frontend
{
    public List<Service> Services { get; } = new();
    public List<Component> Components { get; } = new();
}
