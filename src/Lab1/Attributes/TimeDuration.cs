namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record TimeDuration
{
    public double Value { get; private set; }

    public TimeDuration(double time)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(time);
        Value = time;
    }
}