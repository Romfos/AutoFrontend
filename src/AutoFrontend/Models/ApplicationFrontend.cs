using System.Collections.Generic;

namespace AutoFrontend.Models;

public sealed class ApplicationFrontend
{
    public List<Service> Services { get; } = new();
}