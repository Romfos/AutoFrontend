using AutoFrontend.Models;

namespace AutoFrontend.Builders;

public sealed class ComponentBuilder
{
    private readonly ComponentModel componentModel;

    public ComponentBuilder(ComponentModel componentModel)
    {
        this.componentModel = componentModel;
    }
}
