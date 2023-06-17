using System;

namespace AutoFrontend.Models;

public sealed class ResultModel
{
    public Type Type { get; }
    public bool IsAsync { get; }

    public ResultModel(Type type, bool isAsync)
    {
        Type = type;
        IsAsync = isAsync;
    }
}