using AutoFrontend.Models;
using System.Reflection;

namespace AutoFrontend.Builders;

public sealed class FrontendBuilder
{
    private readonly Frontend frontend = new();

    public Frontend ToFrontend()
    {
        return frontend;
    }

    public ServiceBuilder Service(string name)
    {
        var service = new Service(name);
        frontend.Services.Add(service);
        return new ServiceBuilder(service);
    }

    public ServiceBuilder Service(object service)
    {
        var type = service.GetType();
        var serviceBuilder = Service(type.Name);

        var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly;
        foreach (var method in type.GetMethods(bindingFlags))
        {
            serviceBuilder.Function(service, method);
        }

        return serviceBuilder;
    }

    public ComponentBuilder Component<TComponent, TValue>()
    {
        var component = new Component(typeof(TComponent), typeof(TValue));
        frontend.Components.Add(component);
        return new ComponentBuilder(component);
    }
}
