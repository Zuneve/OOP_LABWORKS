namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record Time
{
    public double Value { get; private set; }

    public Time(double time)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(time);
        Value = time;
    }
}