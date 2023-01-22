using AutoFrontend.Models;
using System;
using System.Reflection;

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
        var actionModel = new ActionModel(@delegate.Target, @delegate.Method);
        serviceModel.Actions.Add(actionModel);
        return new ActionBuilder(actionModel);
    }

    public ActionBuilder Action(object target, MethodInfo methodInfo)
    {
        var actionModel = new ActionModel(target, methodInfo);
        serviceModel.Actions.Add(actionModel);
        return new ActionBuilder(actionModel);
    }
}
