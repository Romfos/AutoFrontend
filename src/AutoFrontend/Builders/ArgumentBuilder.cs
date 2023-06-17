using AutoFrontend.Models;

namespace AutoFrontend.Builders;

public sealed class ArgumentBuilder
{
    private readonly ArgumentModel argument;

    public ArgumentBuilder(ArgumentModel argument)
    {
        this.argument = argument;
    }
}

