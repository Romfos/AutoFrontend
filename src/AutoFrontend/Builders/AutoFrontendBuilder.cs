using AutoFrontend.Models;

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
}
