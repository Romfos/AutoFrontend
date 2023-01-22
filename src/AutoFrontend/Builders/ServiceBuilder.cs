using AutoFrontend.Models;
using System;

namespace AutoFrontend.Builders;

public sealed class ServiceBuilder
{
    private readonly ServiceModel serviceModel;

    public ServiceBuilder(ServiceModel serviceModel)
    {
        this.serviceModel = serviceModel;
    }

    public ActionBuilder Action(Delegate @delegate)
    {
        var actionModel = new ActionModel(@delegate);
        serviceModel.Actions.Add(actionModel);
        return new ActionBuilder(actionModel);
    }
}
