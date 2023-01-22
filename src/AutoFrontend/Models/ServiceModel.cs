using System.Collections.Generic;

namespace AutoFrontend.Models;

public sealed class ServiceModel
{
    public string Name { get; }
    public List<ActionModel> Actions { get; }

    public ServiceModel(string name)
    {
        Name = name;
        Actions = new();
    }

    public override string ToString()
    {
        return $"Service: {Name}";
    }
}
