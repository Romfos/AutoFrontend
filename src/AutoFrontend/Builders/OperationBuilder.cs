using AutoFrontend.Models;
using System;

namespace AutoFrontend.Builders;

public sealed class OperationBuilder
{
    private readonly Operation operation;

    public OperationBuilder(Operation operation)
    {
        this.operation = operation;
    }

    public ArgumentBuilder Argument(string name, Type argumentType)
    {
        var argument = new Argument(name, argumentType);
        operation.Arguments.Add(argument);
        return new ArgumentBuilder(argument);
    }
}

