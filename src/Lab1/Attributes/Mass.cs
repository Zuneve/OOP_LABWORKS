namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record Mass
{
    public double Value { get; }

    public Mass(double mass)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(mass);
        Value = mass;
    }
}