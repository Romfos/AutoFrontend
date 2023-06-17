using System.Collections.Generic;

namespace AutoFrontend.Models;

public sealed class FrontendModel
{
    public List<ServiceModel> Services { get; } = new();
}
