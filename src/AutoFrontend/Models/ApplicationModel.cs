using System.Collections.Generic;

namespace AutoFrontend.Models;

public sealed class ApplicationModel
{
    public IReadOnlyList<Query> Queries { get; }
    public IReadOnlyList<Command> Commands { get; }

    public ApplicationModel(IReadOnlyList<Query> queries, IReadOnlyList<Command> commands)
    {
        Queries = queries;
        Commands = commands;
    }
}
