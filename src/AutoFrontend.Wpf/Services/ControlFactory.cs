using AutoFrontend.Wpf.Controls.Arguments;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Services;

public sealed class ControlFactory
{
    private readonly Dictionary<Type, Func<Control>> factories = CreateDefaultFactories();

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

    private static Dictionary<Type, Func<Control>> CreateDefaultFactories()
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

    public void AddCustomControl<TControl, TValue>()
        where TControl : Control, IArgumentControl, new()
    {
        factories[typeof(TValue)] = () => new TControl();
    }
}
