using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using TestFixture;

namespace AutoFrontend.Wpf.Services;

public sealed class ControlFactory
{
    private readonly Fixture fixture;
    private readonly Dictionary<Type, Func<Argument, Control>> factories;

    public ControlFactory(Fixture fixture)
    {
        this.fixture = fixture;

        factories = CreateDefaultFactories();
    }

    public Control Create(Argument argument)
    {
        if (factories.TryGetValue(argument.ArgumentType, out var factory))
        {
            return factory(argument);
        }
        else
        {
            return new JsonStringControl(argument, fixture);
        }
    }

    private Dictionary<Type, Func<Argument, Control>> CreateDefaultFactories()
    {
        return new()
        {
            [typeof(string)] = argument => new DefaultStringControl(argument),
            [typeof(bool)] = (Argument argument) => argument.IsResult ? new DefaultTrueFalseControl(argument) : new DefaultBoolControl(argument),
            [typeof(DateTime)] = argument => new CustomDateTimeControl(argument),
            [typeof(DateTimeOffset)] = argument => new CustomDateTimeControl(argument),
            [typeof(TimeSpan)] = argument => new CustomDateTimeControl(argument),
#if NET6_0_OR_GREATER
            [typeof(TimeOnly)] = argument => new CustomDateTimeControl(argument),
            [typeof(DateOnly)] = argument => new CustomDateTimeControl(argument),
#endif
            [typeof(int)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => int.TryParse(x, out var value) ? value : null
            },
            [typeof(byte)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => byte.TryParse(x, out var value) ? value : null
            },
            [typeof(sbyte)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => sbyte.TryParse(x, out var value) ? value : null
            },
            [typeof(short)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => short.TryParse(x, out var value) ? value : null
            },
            [typeof(ushort)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => ushort.TryParse(x, out var value) ? value : null
            },
            [typeof(uint)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => uint.TryParse(x, out var value) ? value : null
            },
            [typeof(long)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => long.TryParse(x, out var value) ? value : null
            },
            [typeof(ulong)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => ulong.TryParse(x, out var value) ? value : null
            },
            [typeof(float)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => float.TryParse(x, out var value) ? value : null
            },
            [typeof(double)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => double.TryParse(x, out var value) ? value : null
            },
            [typeof(decimal)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => decimal.TryParse(x, out var value) ? value : null
            },
            [typeof(Guid)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => Guid.TryParse(x, out var value) ? value : null
            },
            [typeof(char)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => char.TryParse(x, out var value) ? value : null
            },
            [typeof(Uri)] = argument => new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x =>
                {
                    try
                    {
                        return new Uri(x);
                    }
                    catch
                    {
                        return null;
                    }
                }
            },
        };
    }

    public void AddCustomControl<TControl, TValue>(Func<Argument, TControl> factory)
        where TControl : Control, IArgumentControl
    {
        factories[typeof(TValue)] = factory;
    }
}
