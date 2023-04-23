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

    public OperationBuilder Operation(Delegate @delegate)
    {
        return Operation(@delegate.Target, @delegate.Method);
    }

    public OperationBuilder Operation(object? target, MethodInfo methodInfo)
    {
        return Operation(target, methodInfo, methodInfo.Name);
    }

    public OperationBuilder Operation(object? target, MethodInfo methodInfo, string name)
    {
        var operationResult = CreateOperationResult(methodInfo.ReturnType);
        var operation = new Operation(name, target, methodInfo, operationResult);
        var operationBuilder = new OperationBuilder(operation);

        foreach (var parameterInfo in methodInfo.GetParameters())
        {
            if (parameterInfo?.Name == null)
            {
                throw new Exception($"Unable to get parameter for {methodInfo.Name}");
            }
            operationBuilder.Argument(parameterInfo.Name, parameterInfo.ParameterType);
        }

        service.Operations.Add(operation);
        return operationBuilder;
    }

    private OperationResult CreateOperationResult(Type valueType)
    {
        if (valueType == typeof(Task))
        {
            return new(typeof(void), true);
        }
        if (valueType == typeof(ValueTask))
        {
            return new(typeof(void), true);
        }

        if (valueType.IsGenericType)
        {
            var genericArguments = valueType.GetGenericArguments();
            if (genericArguments.Length == 1)
            {
                var genericType = genericArguments.Single();
                if (valueType == typeof(Task<>).MakeGenericType(genericType))
                {
                    return new(genericType, true);
                }
                if (valueType == typeof(ValueTask<>).MakeGenericType(genericType))
                {
                    return new(genericType, true);
                }
            }
        }

        return new(valueType, false);
    }
}

