using System.Collections.Generic;
using AutoFrontend.Models;

namespace AutoFrontend;

public interface IApplicationRuntime
{
    void Run(ApplicationModel applicationModel);
}
