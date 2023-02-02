using AutoFrontend.Models;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AutoFrontend.Builders;

public sealed class ServiceBuilder
{
    private readonly Service service;

    public ServiceBuilder(Service service)
    {
        this.service = service;
    }

    public FunctionBuilder Function(Delegate @delegate)
    {
        return Function(@delegate.Target, @delegate.Method);
    }

    public FunctionBuilder Function(object? target, MethodInfo methodInfo)
    {
        return Function(target, methodInfo, methodInfo.Name);
    }

    public FunctionBuilder Function(object? target, MethodInfo methodInfo, string name)
    {
        var function = CreateFunction(target, methodInfo, name);
        var functionBuilder = new FunctionBuilder(function);

        foreach (var parameterInfo in methodInfo.GetParameters())
        {
            if (parameterInfo == null)
            {
                throw new Exception($"Unable to get parameter for {methodInfo.Name}");
            }
            functionBuilder.Argument(parameterInfo.Name, parameterInfo.ParameterType);
        }

        service.Functions.Add(function);
        return functionBuilder;
    }

    private Function CreateFunction(object? target, MethodInfo methodInfo, string name)
    {
        if (methodInfo.ReturnType == typeof(Task))
        {
            return new(target, methodInfo, name, new Definition(typeof(void)), true);
        }
        if (methodInfo.ReturnType == typeof(ValueTask))
        {
            return new(target, methodInfo, name, new Definition(typeof(void)), true);
        }
        if (methodInfo.ReturnType.IsGenericType)
        {
            var genericArguments = methodInfo.ReturnType.GetGenericArguments();
            if (genericArguments.Length == 1)
            {
                var genericType = genericArguments[0];
                if (methodInfo.ReturnType == typeof(Task<>).MakeGenericType(genericType))
                {
                    return new(target, methodInfo, name, new Definition(genericType), true);
                }
                if (methodInfo.ReturnType == typeof(ValueTask<>).MakeGenericType(genericType))
                {
                    return new(target, methodInfo, name, new Definition(genericType), true);
                }
            }
        }
        return new(target, methodInfo, name, new Definition(methodInfo.ReturnType), false);
    }
}
