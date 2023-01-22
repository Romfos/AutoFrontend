using Playground.Models;
using System.Collections.Generic;

namespace Playground.Services;

public sealed class UserService
{
    private readonly List<User> users = new();

    public IEnumerable<User> GetUsers()
    {
        return users;
    }

    public void AddUser(string name, int age)
    {
        users.Add(new User(name, age));
    }

    public void DeleteUser(string name)
    {
        users.RemoveAll(x => x.Name == name);
    }
}
