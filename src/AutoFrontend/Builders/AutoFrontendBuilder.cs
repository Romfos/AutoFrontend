using AutoFrontend.Models;
using System.Reflection;

namespace AutoFrontend.Builders;

public sealed class AutoFrontendBuilder
{
    private readonly AutoFrontendModel autoFrontendModel = new();

    public AutoFrontendModel ToAutoFrontendModel()
    {
        return autoFrontendModel;
    }

    public ServiceBuilder Service(string name)
    {
        var serviceModel = new ServiceModel(name);
        autoFrontendModel.Services.Add(serviceModel);
        return new ServiceBuilder(serviceModel);
    }

    public ServiceBuilder Service(object service)
    {
        var type = service.GetType();
        var serviceBuilder = Service(type.Name);
        var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly;
        foreach (var method in type.GetMethods(bindingFlags))
        {
            serviceBuilder.Action(service, method);
        }
        return serviceBuilder;
    }

    public ComponentBuilder Component<TComponent, TValue>()
    {
        var componentModel = new ComponentModel(typeof(TComponent), typeof(TValue));
        autoFrontendModel.Components.Add(componentModel);
        return new ComponentBuilder(componentModel);
    }
}
