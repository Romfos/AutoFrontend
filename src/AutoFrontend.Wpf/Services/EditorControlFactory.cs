using AutoFrontend.Wpf.Controls.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace AutoFrontend.Wpf.Services;

public sealed class EditorControlFactory
{
    private readonly List<Func<Type, IEditorControl?>> factories = new(100);

    internal EditorControlFactory()
    {
        Register(x => x == typeof(void)
            ? new TextEditorControl(x => "Done", x => null, "Done")
            : null);

        RegisterTextEditorControl<byte>("0", x => byte.TryParse(x, out var v) ? v : null);
        RegisterTextEditorControl<sbyte>("0", x => sbyte.TryParse(x, out var v) ? v : null);
        RegisterTextEditorControl<short>("0", x => short.TryParse(x, out var v) ? v : null);
        RegisterTextEditorControl<ushort>("0", x => ushort.TryParse(x, out var v) ? v : null);
        RegisterTextEditorControl<int>("0", x => int.TryParse(x, out var v) ? v : null);
        RegisterTextEditorControl<uint>("0", x => uint.TryParse(x, out var v) ? v : null);
        RegisterTextEditorControl<long>("0", x => long.TryParse(x, out var v) ? v : null);
        RegisterTextEditorControl<ulong>("0", x => ulong.TryParse(x, out var v) ? v : null);
        RegisterTextEditorControl<decimal>("0", x => decimal.TryParse(x, out var v) ? v : null);

        RegisterTextEditorControl<DateTime>(DateTime.UtcNow.ToString(), x => DateTime.TryParse(x, out var v) ? v : null);
        RegisterTextEditorControl<DateTimeOffset>(DateTimeOffset.UtcNow.ToString(), x => DateTimeOffset.TryParse(x, out var v) ? v : null);
#if NET6_0_OR_GREATER
        RegisterTextEditorControl<DateOnly>(DateOnly.FromDateTime(DateTime.UtcNow).ToString(), x => DateOnly.TryParse(x, out var v) ? v : null);
        RegisterTextEditorControl<TimeOnly>(TimeOnly.FromDateTime(DateTime.UtcNow).ToString(), x => TimeOnly.TryParse(x, out var v) ? v : null);
#endif
        RegisterTextEditorControl<Uri>("http://test.com", x => Uri.TryCreate(x, UriKind.RelativeOrAbsolute, out var v) ? v : null);
        RegisterTextEditorControl<char>("-", x => char.TryParse(x, out var v) ? v : null);
    }

    internal void RegisterTextEditorControl<T>(string defaultValue, Func<string, object?> parser) where T : notnull
    {
        Register(x => x == typeof(T)
            ? new TextEditorControl(
                x => x?.ToString() ?? defaultValue,
                x => x != null && parser(x) is object v ? v : throw new Exception($"Invalid value. {typeof(T).FullName} is expected"),
                defaultValue)
            : null);
    }

    internal void Register(Func<Type, IEditorControl?> factory)
    {
        factories.Insert(0, factory);
    }

    public IEditorControl Create(Type type)
    {
        var control = factories.Select(factory => factory(type)).FirstOrDefault(x => x != null);

        return control switch
        {
            Control => control,
            null => new JsonEditorControl(type),
            _ => throw new Exception($"Type {control.GetType().FullName} should be wpf control")
        };
    }
}
