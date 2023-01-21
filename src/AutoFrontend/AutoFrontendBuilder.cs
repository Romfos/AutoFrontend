using System;
using System.Collections.Generic;

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

    public void Run(IApplication application)
    {
        application.Run(queries, commands);
    }
}
