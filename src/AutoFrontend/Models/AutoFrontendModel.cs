using System.Collections.Generic;

namespace AutoFrontend.Models;

public sealed class AutoFrontendModel
{
    public List<ServiceModel> Services { get; } = new();
}