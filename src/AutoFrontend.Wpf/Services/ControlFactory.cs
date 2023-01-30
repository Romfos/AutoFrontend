using AutoFrontend.Models;
using AutoFrontend.Wpf.Controls.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using TestFixture;

namespace AutoFrontend.Wpf.Services;

public sealed class ControlFactory
{
    private readonly Fixture fixture;
    private readonly List<Func<Argument, Control?>> factories;

    public ControlFactory(Fixture fixture)
    {
        this.fixture = fixture;

        factories = CreateDefaultFactories().ToList();
    }

    public Control Create(Argument argument)
    {
        var control = factories.Select(factory => factory(argument)).FirstOrDefault(x => x != null);
        return control ?? new JsonStringControl(argument, fixture);
    }

    public void AddCustomControl<TControl, TValue>(Func<Argument, Control?> factory)
        where TControl : Control, IArgumentControl
    {
        factories.Insert(0, factory);
    }

    private IEnumerable<Func<Argument, Control?>> CreateDefaultFactories()
    {
        yield return argument => argument.ArgumentType == typeof(string)
            ? new DefaultStringControl(argument)
            : null;
        yield return argument => argument.ArgumentType == typeof(bool) && argument.IsResult
            ? new DefaultTrueFalseControl(argument)
            : null;
        yield return argument => argument.ArgumentType == typeof(bool) && !argument.IsResult
            ? new DefaultBoolControl(argument)
            : null;
        yield return argument => argument.ArgumentType == typeof(DateTime)
            ? new CustomDateTimeControl(argument)
            : null;
        yield return argument => argument.ArgumentType == typeof(DateTimeOffset)
            ? new CustomDateTimeControl(argument)
            : null;
        yield return argument => argument.ArgumentType == typeof(TimeSpan)
            ? new CustomDateTimeControl(argument)
            : null;
#if NET6_0_OR_GREATER
        yield return argument => argument.ArgumentType == typeof(TimeOnly)
            ? new CustomDateTimeControl(argument)
            : null;
        yield return argument => argument.ArgumentType == typeof(DateOnly)
            ? new CustomDateTimeControl(argument)
            : null;
#endif
        yield return argument => argument.ArgumentType == typeof(int)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => int.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(byte)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => byte.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(sbyte)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => sbyte.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(short)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => short.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(ushort)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => ushort.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(uint)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => uint.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(long)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => long.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(ulong)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => ulong.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(float)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => float.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(double)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => double.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(decimal)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => decimal.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(Guid)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => Guid.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(char)
            ? new CustomStringControl(argument, fixture)
            {
                TryParseDelegate = x => char.TryParse(x, out var value) ? value : null
            }
            : null;
        yield return argument => argument.ArgumentType == typeof(Uri)
            ? new CustomStringControl(argument, fixture)
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
            }
            : null;
    }
}
