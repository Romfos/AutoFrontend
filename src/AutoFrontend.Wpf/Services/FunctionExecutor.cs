using AutoFrontend.Models;
using System.Threading.Tasks;

namespace AutoFrontend.Wpf.Services;

public sealed class FunctionExecutor
{
    public async Task<object?> ExecuteFunctionAsync(Function function, object?[]? parameters)
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
