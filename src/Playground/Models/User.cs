namespace Playground.Models;

public sealed class User
{
    public string Name { get; }
    public int Age { get; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
