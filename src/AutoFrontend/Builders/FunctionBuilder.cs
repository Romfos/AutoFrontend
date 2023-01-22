using AutoFrontend.Models;

namespace AutoFrontend.Builders;

public sealed class FunctionBuilder
{
    private readonly Function function;

    public FunctionBuilder(Function function)
    {
        this.function = function;
    }
}
