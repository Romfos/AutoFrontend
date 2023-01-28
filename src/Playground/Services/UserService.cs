using Playground.Models;
using System;
using System.Threading.Tasks;

namespace Playground.Services;

public sealed class UserService
{
    public void Void()
    {
    }

    public void ModelArgument(Model model)
    {
    }

    public void StringArgument(string stringValue)
    {
    }

    public void Exception()
    {
        throw new Exception(nameof(Exception));
    }

    public Task TaskVoid()
    {
        return Task.CompletedTask;
    }

    public async Task<string> TaskResult()
    {
        await Task.Delay(1000);
        return nameof(TaskResult);
    }

    public async Task TaskException()
    {
        await Task.Delay(1000);
        throw new Exception(nameof(TaskException));
    }

    public async ValueTask ValueTaskVoid()
    {
        await Task.Delay(1000);
    }

    public async ValueTask<string> ValueTaskResult()
    {
        await Task.Delay(1000);
        return nameof(TaskResult);
    }

    public async ValueTask ValueTaskException()
    {
        await Task.Delay(1000);
        throw new Exception(nameof(ValueTaskException));
    }
}
