using AutoFrontend.Models;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AutoFrontend.Builders;

public sealed class ServiceBuilder
{
    private readonly ServiceModel service;

    public ServiceBuilder(ServiceModel service)
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
        var operationResult = CreateResultModel(methodInfo.ReturnType);
        var operation = new OperationModel(name, target, methodInfo, operationResult);
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

    private ResultModel CreateResultModel(Type returnType)
    {
        if (returnType == typeof(Task))
        {
            return new(typeof(void), true);
        }
        if (returnType == typeof(ValueTask))
        {
            return new(typeof(void), true);
        }

        if (returnType.IsGenericType)
        {
            var genericArguments = returnType.GetGenericArguments();
            if (genericArguments.Length == 1)
            {
                var genericType = genericArguments.Single();
                if (returnType == typeof(Task<>).MakeGenericType(genericType))
                {
                    return new(genericType, true);
                }
                if (returnType == typeof(ValueTask<>).MakeGenericType(genericType))
                {
                    return new(genericType, true);
                }
            }
        }

        return new(returnType, false);
    }
}

