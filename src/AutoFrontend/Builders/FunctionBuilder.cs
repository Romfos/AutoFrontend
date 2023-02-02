using AutoFrontend.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AutoFrontend.Builders;

public sealed class FunctionBuilder
{
    private readonly Function function;

    public FunctionBuilder(Function function)
    {
        this.function = function;
    }

    public ArgumentBuilder Argument(string? name, Type type)
    {
        var argument = new Argument(name, new Definition(type));
        function.Arguments.Add(argument);
        return new ArgumentBuilder(argument);
    }
}
