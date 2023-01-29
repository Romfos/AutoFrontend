using AutoFrontend.Models;
using System;
using System.Threading.Tasks;

namespace AutoFrontend.Wpf.Services;

public sealed class GlobalFunctionService
{
    public event Action? OnFunctionExecuted;

    public async Task<object?> ExecuteWithNotificationAsync(Function function, object?[]? parameters)
    {
        var result = await ExecuteAsync(function, parameters);
        OnFunctionExecuted?.Invoke();
        return result;
    }

    public async Task<object?> ExecuteAsync(Function function, object?[]? parameters)
    {
        if (function.Result.IsTask || function.Result.IsValueTask)
        {
            if (function.Result.AwaitResultType == typeof(void))
            {
                await (dynamic?)function.MethodInfo.Invoke(function.Target, parameters);
                return null;
            }
            else
            {
                return await (dynamic?)function.MethodInfo.Invoke(function.Target, parameters);
            }
        }

        if (function.Result.AwaitResultType == typeof(void))
        {
            await Task.Run(() =>
            {
                function.MethodInfo.Invoke(function.Target, parameters);
            });
            return null;
        }
        else
        {
            return await Task.Run(() =>
            {
                return function.MethodInfo.Invoke(function.Target, parameters);
            });
        }
    }
}
