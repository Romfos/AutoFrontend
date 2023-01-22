using System.Reflection;

namespace AutoFrontend.Models;

public sealed class Function
{
    public object? Target { get; }
    public MethodInfo MethodInfo { get; }
    public string Name { get; set; }

    public Function(object? target, MethodInfo methodInfo)
    {
        Target = target;
        MethodInfo = methodInfo;
        Name = methodInfo.Name;
    }
}
