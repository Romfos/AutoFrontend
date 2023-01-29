namespace Playground.Services;

public sealed class CalculatorService
{
    private int acumulator;

    public int Get()
    {
        return acumulator;
    }

    public void Set(int value)
    {
        acumulator = value;
    }

    public void Add(int value)
    {
        acumulator += value;
    }

    public void Substract(int value)
    {
        acumulator -= value;
    }
}
