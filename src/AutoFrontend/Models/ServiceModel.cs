using System.Collections.Generic;

namespace AutoFrontend.Models;

public sealed class ServiceModel(string name)
{
    public string Name { get; } = name;
    public List<OperationModel> Operations { get; } = new();
}
