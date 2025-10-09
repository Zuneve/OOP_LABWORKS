namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record TimeDuration
{
    public double Value { get; }

    public TimeDuration(double time)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(time);
        Value = time;
    }
}