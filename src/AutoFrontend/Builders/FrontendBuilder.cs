using AutoFrontend.Models;
using System.Reflection;

namespace AutoFrontend.Builders;

public sealed class FrontendBuilder
{
    private readonly FrontendModel frontendModel = new();

    public FrontendModel ToFrontendModel()
    {
        return frontendModel;
    }

    public ServiceBuilder Service(string name)
    {
        var service = new ServiceModel(name);
        frontendModel.Services.Add(service);
        return new ServiceBuilder(service);
    }

    public ServiceBuilder Service(object service)
    {
        var type = service.GetType();
        var serviceBuilder = Service(type.Name);

        var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly;
        foreach (var method in type.GetMethods(bindingFlags))
        {
            serviceBuilder.Operation(service, method);
        }

        return serviceBuilder;
    }
}
