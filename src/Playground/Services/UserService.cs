using Playground.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Playground.Services;

public sealed class UserService
{
    public IEnumerable<User> ReturnEnumerableOfModels()
    {
        yield return new User("abcd", 123);
    }

    public void ModelArgument(User user)
    {
    }

    public void StringArgument(string name)
    {
    }

    public void Exception()
    {
        throw new Exception("Exception messgae");
    }

    public async Task<string> AsyncString()
    {
        await Task.Delay(2000);
        return nameof(AsyncString);
    }

    public async Task AsyncException()
    {
        await Task.Delay(2000);
        throw new Exception(nameof(AsyncException));
    }
}
