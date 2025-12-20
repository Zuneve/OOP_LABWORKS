namespace Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

public sealed record Balance
{
    public Balance(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }
}