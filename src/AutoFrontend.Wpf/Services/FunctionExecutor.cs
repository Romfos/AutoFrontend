using AutoFrontend.Models;
using System.Threading.Tasks;

namespace AutoFrontend.Wpf.Services;

public sealed class FunctionExecutor
{
    public async Task<object?> ExecuteFunctionAsync(Function function, object?[] parameters)
    {
        var result = function.MethodInfo.Invoke(function.Target, parameters);
        if (IsAsyncDataType(result, out var task))
        {
            return await task;
        }
        return result;
    }

    private bool IsAsyncDataType(object? result, out dynamic? task)
    {
        if (result != null && result.GetType().GetMethod(nameof(Task.GetAwaiter)) != null)
        {
            task = result;
            return true;
        }
        task = null;
        return false;
    }
}
