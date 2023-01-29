using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Services;

public sealed class ControlFactory
{
    private readonly Dictionary<Type, Func<Control>> factories;

    public ControlFactory(List<Component> customComponents)
    {
        factories = CreateDefaultFactories();
        OverrideFactories(factories, customComponents);
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
                ParseFunction = x => int.TryParse(x, out var value) ? value : null
            },
            [typeof(byte)] = () => new CustomStringControl
            {
                ParseFunction = x => byte.TryParse(x, out var value) ? value : null
            },
            [typeof(sbyte)] = () => new CustomStringControl
            {
                ParseFunction = x => sbyte.TryParse(x, out var value) ? value : null
            },
            [typeof(short)] = () => new CustomStringControl
            {
                ParseFunction = x => short.TryParse(x, out var value) ? value : null
            },
            [typeof(ushort)] = () => new CustomStringControl
            {
                ParseFunction = x => ushort.TryParse(x, out var value) ? value : null
            },
            [typeof(uint)] = () => new CustomStringControl
            {
                ParseFunction = x => uint.TryParse(x, out var value) ? value : null
            },
            [typeof(long)] = () => new CustomStringControl
            {
                ParseFunction = x => long.TryParse(x, out var value) ? value : null
            },
            [typeof(ulong)] = () => new CustomStringControl
            {
                ParseFunction = x => ulong.TryParse(x, out var value) ? value : null
            },
            [typeof(float)] = () => new CustomStringControl
            {
                ParseFunction = x => float.TryParse(x, out var value) ? value : null
            },
            [typeof(double)] = () => new CustomStringControl
            {
                ParseFunction = x => double.TryParse(x, out var value) ? value : null
            },
            [typeof(decimal)] = () => new CustomStringControl
            {
                ParseFunction = x => decimal.TryParse(x, out var value) ? value : null
            },
        };
    }

    private void OverrideFactories(Dictionary<Type, Func<Control>> overriede, IEnumerable<Component> customComponents)
    {
        foreach (var customComponent in customComponents)
        {
            overriede[customComponent.ValueType] = () =>
            {
                if (Activator.CreateInstance(customComponent.ComponentType) is not Control control)
                {
                    throw new Exception($"Component {customComponent.ComponentType} should be wpf control");
                }
                if (control is not IArgumentControl)
                {
                    throw new Exception($"Component {customComponent.ComponentType} should implement {nameof(IArgumentControl)}");
                }
                return control;
            };
        }
    }
}
