using AutoFrontend.Models;
using System;
using System.Reflection;

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
        var function = new Function(target, methodInfo);
        var functionBuilder = new FunctionBuilder(function);

        functionBuilder.Result(methodInfo.ReturnParameter.ParameterType);

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
}
