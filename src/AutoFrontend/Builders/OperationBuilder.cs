using AutoFrontend.Models;

namespace AutoFrontend.Builders;

public sealed class OperationBuilder(OperationModel operation)
{
    public ArgumentBuilder Argument(string name, Type argumentType)
    {
        var argument = new ArgumentModel(name, argumentType);
        operation.Arguments.Add(argument);
        return new ArgumentBuilder();
    }
}

