using Playground.Enums;
using Playground.Models;

namespace Playground.Services;

public sealed class UserService
{
    public void Void()
    {
    }

    public Model Model(Model argument)
    {
        return argument;
    }

    public string String(string argument)
    {
        return argument;
    }

    public char Char(char argument)
    {
        return argument;
    }

    public Uri Uri(Uri argument)
    {
        return argument;
    }

    public DateTime DateTime(DateTime argument)
    {
        return argument;
    }

    public DateTimeOffset DateTimeOffset(DateTimeOffset argument)
    {
        return argument;
    }

    public TimeSpan TimeSpan(TimeSpan argument)
    {
        return argument;
    }

#if NET
    public TimeOnly TimeOnly(TimeOnly argument)
    {
        return argument;
    }

    public DateOnly DateOnly(DateOnly argument)
    {
        return argument;
    }
#endif

    public Guid Guid(Guid argument)
    {
        return argument;
    }

    public bool Bool(bool argument)
    {
        return argument;
    }

    public Enum1 Enum(Enum1 argument)
    {
        return argument;
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
        return new string('$', 10000);
    }

    public async ValueTask ValueTaskException()
    {
        await Task.Delay(1000);
        throw new Exception(nameof(ValueTaskException));
    }
}
