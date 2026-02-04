namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record MaxAllowedSpeed
{
    public double Value { get; }

    public MaxAllowedSpeed(double maxAllowedSpeed)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(maxAllowedSpeed);
        Value = maxAllowedSpeed;
    }
}