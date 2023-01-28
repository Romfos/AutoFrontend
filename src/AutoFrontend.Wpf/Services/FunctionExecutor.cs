using AutoFrontend.Models;
using System.Threading.Tasks;

namespace AutoFrontend.Wpf.Services;

public sealed class FunctionExecutor
{
    public async Task<object?> ExecuteFunctionAsync(Function function, object?[] parameters)
    {
        var returnType = function.MethodInfo.ReturnType;
        var result = function.MethodInfo.Invoke(function.Target, parameters);

        if (returnType == typeof(void) || result == null)
        {
            return null;
        }
        if (returnType == typeof(Task) || returnType == typeof(ValueTask))
        {
            await (dynamic)result;
            return null;
        }
        if (returnType.GetMethod(nameof(Task.GetAwaiter)) != null)
        {
            return await (dynamic)result;
        }
        return result;
    }
}
