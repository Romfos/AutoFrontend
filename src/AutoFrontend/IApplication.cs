using System.Collections.Generic;

namespace AutoFrontend;

public interface IApplication
{
    void Run(IEnumerable<Query> queries, IEnumerable<Command> commands);
}
