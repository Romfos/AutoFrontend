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
        var (awaitResultType, isTask, isValueTask) = GetAsyncInformation(valueType);
        var argument = new Argument(name, awaitResultType, isTask, isValueTask);
        function.Arguments.Add(argument);
        return new ArgumentBuilder(argument);
    }

    public ArgumentBuilder Result(Type valueType)
    {
        var (awaitResultType, isTask, isValueTask) = GetAsyncInformation(valueType);
        function.Result = new Argument("Result", awaitResultType, isTask, isValueTask);
        return new ArgumentBuilder(function.Result);
    }

    private (Type awaitResultType, bool isTask, bool isValueTask) GetAsyncInformation(Type valueType)
    {
        if (valueType == typeof(Task))
        {
            return (typeof(void), true, false);
        }
        if (valueType == typeof(ValueTask))
        {
            return (typeof(void), false, true);
        }

        if (valueType.IsGenericType)
        {
            var genericArguments = valueType.GetGenericArguments();
            if (genericArguments.Length == 1)
            {
                var genericType = genericArguments.Single();
                if (valueType == typeof(Task<>).MakeGenericType(genericType))
                {
                    return (genericType, true, false);
                }
                if (valueType == typeof(ValueTask<>).MakeGenericType(genericType))
                {
                    return (genericType, false, true);
                }
            }
        }
        return (valueType, false, false);
    }
}
