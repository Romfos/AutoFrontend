using System;

namespace AutoFrontend.Models;

public sealed class OperationResult
{
    public Type Type { get; }
    public bool IsAsync { get; }

    public OperationResult(Type type, bool isAsync)
    {
        Type = type;
        IsAsync = isAsync;
    }
}