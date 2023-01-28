using AutoFrontend.Models;
using System;
using System.Threading.Tasks;

namespace AutoFrontend.Wpf.Services;

public sealed class FunctionExecutor
{
    public async Task<object?> ExecuteFunctionAsync(Function function, object?[] parameters)
    {
        var returnType = function.MethodInfo.ReturnType;
        if (IsAsyncMethod(returnType))
        {
            if (returnType == typeof(Task) || returnType == typeof(ValueTask))
            {
                await (dynamic?)function.MethodInfo.Invoke(function.Target, parameters);
                return null;
            }
            return await (dynamic?)function.MethodInfo.Invoke(function.Target, parameters);
        }
        else
        {
            if (returnType == typeof(void))
            {
                await Task.Run(async () =>
                {
                    await Task.Delay(300);
                    function.MethodInfo.Invoke(function.Target, parameters);
                });
                return null;
            }
            else
            {
                return await Task.Run(async () =>
                {
                    await Task.Delay(300);
                    return function.MethodInfo.Invoke(function.Target, parameters);
                });
            }
        }
    }

    private bool IsAsyncMethod(Type returnType)
    {
        return returnType.GetMethod(nameof(Task.GetAwaiter)) != null;
    }
}
