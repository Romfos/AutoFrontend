using AutoFrontend.Models;

namespace AutoFrontend.Builders;

public sealed class ActionBuilder
{
    private readonly ActionModel actionModel;

    public ActionBuilder(ActionModel actionModel)
    {
        this.actionModel = actionModel;
    }
}
