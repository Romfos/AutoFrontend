using TestFixture;

namespace AutoFrontend.Wpf.Services;

public sealed class ServiceLocator
{
    public Fixture Fixture { get; } = new();

    public ControlFactory ControlFactory { get; } = new();

    public GlobalFunctionService GlobalFunctionService { get; } = new();
}
