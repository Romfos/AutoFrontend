using System.Collections.Generic;

namespace AutoFrontend.Models;

public sealed class ServiceModel
{
    public string Name { get; }
    public List<ActionModel> Actions { get; } = new();

    public ServiceModel(string name)
    {
        Name = name;
    }
}
