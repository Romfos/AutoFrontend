using System.Reflection;

namespace AutoFrontend.Models;

public sealed class OperationModel(
    string name,
    object? target,
    MethodInfo methodInfo,
    ResultModel result)
{
    public string Name { get; } = name;
    public object? Target { get; } = target;
    public MethodInfo MethodInfo { get; } = methodInfo;

    public List<ArgumentModel> Arguments { get; } = [];
    public ResultModel Result { get; } = result;
}
