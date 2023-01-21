using System.Collections.Generic;
using AutoFrontend.Models;

namespace AutoFrontend;

public interface IApplication
{
    void Run(ApplicationModel applicationModel);
}
