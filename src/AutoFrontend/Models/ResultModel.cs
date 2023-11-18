using System;

namespace AutoFrontend.Models;

public sealed class ResultModel(Type type, bool isAsync)
{
    public Type Type { get; } = type;
    public bool IsAsync { get; } = isAsync;
}