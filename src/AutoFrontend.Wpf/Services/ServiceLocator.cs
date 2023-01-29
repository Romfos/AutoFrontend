using AutoFrontend.Models;
using TestFixture;

namespace AutoFrontend.Wpf.Services;

public sealed class ServiceLocator
{
    public Fixture Fixture { get; } = new();

    public ControlFactory ControlFactory { get; }

    public GlobalFunctionService GlobalFunctionService { get; } = new();

    public ServiceLocator(Frontend frontend)
    {
        ControlFactory = new ControlFactory(frontend.Components);
    }
}
