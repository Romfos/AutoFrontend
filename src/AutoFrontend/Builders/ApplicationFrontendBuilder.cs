using AutoFrontend.Models;
using System.Reflection;

namespace AutoFrontend.Builders;

public sealed class ApplicationFrontendBuilder
{
    private readonly ApplicationFrontend applicationFrontend = new();

    public ApplicationFrontend ToApplicationFrontend()
    {
        return applicationFrontend;
    }

    public ServiceBuilder Service(string name)
    {
        var serivce = new Service(name);
        applicationFrontend.Services.Add(serivce);
        return new ServiceBuilder(serivce);
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
