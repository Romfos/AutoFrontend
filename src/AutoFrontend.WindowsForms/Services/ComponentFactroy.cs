using AutoFrontend.Models;
using AutoFrontend.WindowsForms.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Windows.Forms;

namespace AutoFrontend.WindowsForms.Services;

internal sealed class ComponentFactroy
{
    private readonly ImmutableArray<Component> components;

    public ComponentFactroy(List<Component> components)
    {
        this.components = GetDefaultComponents()
            .Select(defaultComponent => components.Find(x => x.ValueType == x.ValueType) ?? defaultComponent)
            .ToImmutableArray();
    }

    public Control Create(Type valueType)
    {
        var component = components.SingleOrDefault(x => x.ValueType == valueType);
        if (component == null)
        {
            throw new Exception($"Unable to resolve component for type {valueType.FullName}");
        }
        if (Activator.CreateInstance(component.ComponentType) is not Control control)
        {
            throw new Exception($"Component {component.ComponentType} should be windows forms control");
        }
        return control;
    }

    private IEnumerable<Component> GetDefaultComponents()
    {
        yield return new Component(typeof(StringDefaultControl), typeof(string));
    }
}
