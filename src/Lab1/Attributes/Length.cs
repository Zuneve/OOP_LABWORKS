namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record Length
{
    public double Value { get; }

    public Length(double length)
    {
        Value = length;
    }

    public bool IsLessThan(Length other)
    {
        return Value < other.Value;
    }
}