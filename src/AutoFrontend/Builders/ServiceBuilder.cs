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
        var function = new Function(@delegate.Target, @delegate.Method);
        service.Functions.Add(function);
        return new FunctionBuilder(function);
    }

    public FunctionBuilder Function(object target, MethodInfo methodInfo)
    {
        var function = new Function(target, methodInfo);
        service.Functions.Add(function);
        return new FunctionBuilder(function);
    }
}
