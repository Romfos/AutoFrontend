using System.Collections.Generic;

namespace AutoFrontend.Models;

public sealed class Application
{
    public List<Service> Services { get; } = new();
    public List<Component> Components { get; } = new();
}
