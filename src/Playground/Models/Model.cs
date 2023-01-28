namespace Playground.Models;

public sealed class Model
{
    public string StringProperty { get; }
    public int IntProperty { get; }

    public Model(string stringProperty, int intProperty)
    {
        StringProperty = stringProperty;
        IntProperty = intProperty;
    }
}
