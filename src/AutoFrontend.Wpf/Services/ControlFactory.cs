using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Services;

public sealed class ControlFactory
{
    private readonly List<Component> components;

    public ControlFactory(List<Component> customComponents)
    {
        components = GetDefaultComponents()
            .Select(defaultComponent => customComponents.Find(x => x.ValueType == x.ValueType) ?? defaultComponent)
            .ToList();
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
            throw new Exception($"Component {component.ComponentType} should be wpf control");
        }
        if (control is not IArgumentControl)
        {
            throw new Exception($"Component {component.ComponentType} should implement {nameof(IArgumentControl)}");
        }
        return control;
    }

    private IEnumerable<Component> GetDefaultComponents()
    {
        yield return new Component(typeof(StringControl), typeof(string));
        yield return new Component(typeof(Int32Control), typeof(int));
    }
}