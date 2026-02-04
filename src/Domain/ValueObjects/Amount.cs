namespace Itmo.ObjectOrientedProgramming.Domain.ValueObjects;

public sealed record Amount
{
    public Amount(decimal value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        Value = value;
    }

    public decimal Value { get; }
}