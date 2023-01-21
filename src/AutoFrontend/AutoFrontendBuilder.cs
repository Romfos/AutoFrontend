using System;
using System.Collections.Generic;
using AutoFrontend.Models;

namespace AutoFrontend;

public sealed class AutoFrontendBuilder
{
    private readonly List<Query> queries = new();
    private readonly List<Command> commands = new();

    public AutoFrontendBuilder Query(Delegate query)
    {
        queries.Add(new Query(query.Method.Name, query));
        return this;
    }

    public AutoFrontendBuilder Command(Delegate query)
    {
        commands.Add(new Command(query.Method.Name, query));
        return this;
    }

    public void Run(IApplicationRuntime application)
    {
        var applicationModel = new ApplicationModel(queries, commands);
        application.Run(applicationModel);
    }
}
