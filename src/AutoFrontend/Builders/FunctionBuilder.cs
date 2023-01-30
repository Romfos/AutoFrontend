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

    public ArgumentBuilder Argument(string? name, Type valueType)
    {
        var argument = CreateArgument(name, false, valueType);
        function.Arguments.Add(argument);
        return new ArgumentBuilder(argument);
    }

    public ArgumentBuilder Result(Type valueType)
    {
        function.Result = CreateArgument(null, true, valueType);
        return new ArgumentBuilder(function.Result);
    }

    private Argument CreateArgument(string? name, bool isResult, Type valueType)
    {
        if (valueType == typeof(Task))
        {
            return new(name, typeof(void), isResult, true, false);
        }
        if (valueType == typeof(ValueTask))
        {
            return new(name, typeof(void), isResult, false, true);
        }

        if (valueType.IsGenericType)
        {
            var genericArguments = valueType.GetGenericArguments();
            if (genericArguments.Length == 1)
            {
                var genericType = genericArguments.Single();
                if (valueType == typeof(Task<>).MakeGenericType(genericType))
                {
                    return new(name, genericType, isResult, true, false);
                }
                if (valueType == typeof(ValueTask<>).MakeGenericType(genericType))
                {
                    return new(name, genericType, isResult, false, true);
                }
            }
        }
        return new(name, valueType, isResult, false, false);
    }
}
