using AutoFrontend.Models;
using System;

namespace AutoFrontend.Builders;

public sealed class FunctionBuilder
{
    private readonly Function function;

    public FunctionBuilder(Function function)
    {
        this.function = function;
    }

    public ArgumentBuilder Argument(string? name, Type valueType)
    {
        var argument = new Argument(name, valueType);
        function.Arguments.Add(argument);
        return new ArgumentBuilder(argument);
    }

    public ArgumentBuilder Result(Type valueType)
    {
        function.Result = new Argument(null, valueType);
        return new ArgumentBuilder(function.Result);
    }
}
