using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoFrontend.Wpf;

public sealed class ControlFactory
{
    private readonly List<Func<object?, object?>> factories = new();

    public void Register<TArgument>(Func<TArgument, object?> factory)
    {
        factories.Add(x => x is TArgument argument ? factory(argument) : null);
    }

    public T Resolve<T>(object? argument)
    {
        var result = factories
            .Select(x => x(argument))
            .OfType<T>()
            .FirstOrDefault();

        return result ?? throw new Exception($"Unable to resolve control for {argument}");
    }
}
