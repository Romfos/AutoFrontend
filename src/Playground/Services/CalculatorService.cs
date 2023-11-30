namespace Playground.Services;

public sealed class CalculatorService
{
    private int accumulator;

    public int Get()
    {
        return accumulator;
    }

    public void Set(int value)
    {
        accumulator = value;
    }

    public void Add(int value)
    {
        accumulator += value;
    }

    public void Subtract(int value)
    {
        accumulator -= value;
    }
}
