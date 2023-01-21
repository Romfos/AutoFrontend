using System;

namespace AutoFrontend;

public sealed class Query
{
    public string Name { get; }
    public Delegate Delegate { get; }

    public Query(string name, Delegate @delegate)
    {
        Name = name;
        Delegate = @delegate;
    }
}

