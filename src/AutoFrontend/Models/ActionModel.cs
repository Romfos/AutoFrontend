using System.Collections.Generic;
using System.Reflection;

namespace AutoFrontend.Models;

public sealed class ActionModel
{
    public object? Target { get; }
    public MethodInfo MethodInfo { get; }

    public string Name { get; set; }
    public List<FieldModel> Request { get; } = new();
    public List<FieldModel> Response { get; } = new();

    public ActionModel(object? target, MethodInfo methodInfo)
    {
        Target = target;
        MethodInfo = methodInfo;
        Name = methodInfo.Name;
    }

    public override string ToString()
    {
        return $"Action: {Name}";
    }
}
