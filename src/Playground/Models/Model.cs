namespace Playground.Models;

public sealed class Model(string stringProperty, int intProperty)
{
    public string StringProperty { get; } = stringProperty;
    public int IntProperty { get; } = intProperty;
}
