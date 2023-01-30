using Playground.Models;
using System;
using System.Threading.Tasks;

namespace Playground.Services;

public sealed class UserService
{
    public void Void()
    {
    }

    public Model Model(Model model)
    {
        return model;
    }

    public string String(string stringValue)
    {
        return stringValue;
    }

    public char Char(char charValue)
    {
        return charValue;
    }

    public Uri Uri(Uri uriValue)
    {
        return uriValue;
    }

    public DateTime DateTime(DateTime dateTime)
    {
        return dateTime;
    }

    public DateTimeOffset DateTimeOffset(DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset;
    }

    public TimeSpan DateTimeOffset(TimeSpan timeSpan)
    {
        return timeSpan;
    }

#if NET6_0_OR_GREATER
    public TimeOnly TimeOnly(TimeOnly timeOnly)
    {
        return timeOnly;
    }

    public DateOnly DateOnly(DateOnly dateOnly)
    {
        return dateOnly;
    }
#endif

    public Guid Guid(Guid guidValue)
    {
        return guidValue;
    }

    public bool Bool(bool value)
    {
        return value;
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
