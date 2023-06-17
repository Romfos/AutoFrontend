using AutoFrontend.Models;
using System;

namespace AutoFrontend.Builders;

public sealed class OperationBuilder
{
    private readonly OperationModel operation;

    public OperationBuilder(OperationModel operation)
    {
        this.operation = operation;
    }

    public ArgumentBuilder Argument(string name, Type argumentType)
    {
        var argument = new ArgumentModel(name, argumentType);
        operation.Arguments.Add(argument);
        return new ArgumentBuilder(argument);
    }
}

