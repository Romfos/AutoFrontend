using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Services;

public sealed class ControlFactory
{
    private readonly Dictionary<Type, Func<Control>> factories;

    public ControlFactory(List<Component> components)
    {
        factories = CreateDefaultFactories();
        OverrideFactories(factories, components);
    }

    public Control? Create(Type valueType)
    {
        if (factories.TryGetValue(valueType, out var factory))
        {
            return factory();
        }
        else
        {
            return new JsonStringControl();
        }
    }

    private Dictionary<Type, Func<Control>> CreateDefaultFactories()
    {
        return new()
        {
            [typeof(string)] = () => new DefaultStringControl(),
            [typeof(bool)] = () => new DefaultBoolControl(),
            [typeof(int)] = () => new CustomStringControl
            {
                TryParseDelegate = x => int.TryParse(x, out var value) ? value : null
            },
            [typeof(byte)] = () => new CustomStringControl
            {
                TryParseDelegate = x => byte.TryParse(x, out var value) ? value : null
            },
            [typeof(sbyte)] = () => new CustomStringControl
            {
                TryParseDelegate = x => sbyte.TryParse(x, out var value) ? value : null
            },
            [typeof(short)] = () => new CustomStringControl
            {
                TryParseDelegate = x => short.TryParse(x, out var value) ? value : null
            },
            [typeof(ushort)] = () => new CustomStringControl
            {
                TryParseDelegate = x => ushort.TryParse(x, out var value) ? value : null
            },
            [typeof(uint)] = () => new CustomStringControl
            {
                TryParseDelegate = x => uint.TryParse(x, out var value) ? value : null
            },
            [typeof(long)] = () => new CustomStringControl
            {
                TryParseDelegate = x => long.TryParse(x, out var value) ? value : null
            },
            [typeof(ulong)] = () => new CustomStringControl
            {
                TryParseDelegate = x => ulong.TryParse(x, out var value) ? value : null
            },
            [typeof(float)] = () => new CustomStringControl
            {
                TryParseDelegate = x => float.TryParse(x, out var value) ? value : null
            },
            [typeof(double)] = () => new CustomStringControl
            {
                TryParseDelegate = x => double.TryParse(x, out var value) ? value : null
            },
            [typeof(decimal)] = () => new CustomStringControl
            {
                TryParseDelegate = x => decimal.TryParse(x, out var value) ? value : null
            },
            [typeof(Guid)] = () => new CustomStringControl
            {
                TryParseDelegate = x => Guid.TryParse(x, out var value) ? value : null
            },
        };
    }

    private void OverrideFactories(Dictionary<Type, Func<Control>> overriede, IEnumerable<Component> components)
    {
        foreach (var component in components)
        {
            overriede[component.ValueType] = () =>
            {
                if (Activator.CreateInstance(component.ComponentType) is not Control control)
                {
                    throw new Exception($"Component {component.ComponentType} should be wpf control");
                }
                if (control is not IArgumentControl)
                {
                    throw new Exception($"Component {component.ComponentType} should implement {nameof(IArgumentControl)}");
                }
                return control;
            };
        }
    }
}
