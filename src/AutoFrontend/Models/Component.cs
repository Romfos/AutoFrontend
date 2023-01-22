using System;

namespace AutoFrontend.Models;

public sealed class Component
{
    public Type ComponentType { get; }
    public Type ValueType { get; }

    public Component(Type componentType, Type valueType)
    {
        ComponentType = componentType;
        ValueType = valueType;
    }
}
