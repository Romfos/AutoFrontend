using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoFrontend.Models;

public sealed class Definition
{
    public Type Type { get; }

    public Definition(Type type)
    {
        Type = type;
    }
}

