using System;

namespace AutoFrontend.Models;

public sealed class ComponentModel
{
    public Type ComponentType { get; }
    public Type ValueType { get; }

    public ComponentModel(Type componentType, Type valueType)
    {
        ComponentType = componentType;
        ValueType = valueType;
    }
}
