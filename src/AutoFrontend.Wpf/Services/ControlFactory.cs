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
            return new DefaultArgumentControl();
        }
    }

    private Dictionary<Type, Func<Control>> CreateDefaultFactories()
    {
        return new()
        {
            [typeof(string)] = () => new DefaultStringControl(),
            [typeof(int)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => int.TryParse(x, out var value) ? value : null
            },
            [typeof(byte)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => byte.TryParse(x, out var value) ? value : null
            },
            [typeof(sbyte)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => sbyte.TryParse(x, out var value) ? value : null
            },
            [typeof(short)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => short.TryParse(x, out var value) ? value : null
            },
            [typeof(ushort)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => ushort.TryParse(x, out var value) ? value : null
            },
            [typeof(uint)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => uint.TryParse(x, out var value) ? value : null
            },
            [typeof(long)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => long.TryParse(x, out var value) ? value : null
            },
            [typeof(ulong)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => ulong.TryParse(x, out var value) ? value : null
            },
            [typeof(float)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => float.TryParse(x, out var value) ? value : null
            },
            [typeof(double)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => double.TryParse(x, out var value) ? value : null
            },
            [typeof(decimal)] = () => new DefaultParserControl()
            {
                TryParseFunction = x => decimal.TryParse(x, out var value) ? value : null
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
