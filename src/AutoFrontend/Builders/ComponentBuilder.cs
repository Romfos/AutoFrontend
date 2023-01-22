using AutoFrontend.Models;

namespace AutoFrontend.Builders;

public sealed class ComponentBuilder
{
    private readonly Component component;

    public ComponentBuilder(Component component)
    {
        this.component = component;
    }
}
