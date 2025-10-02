namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record Length
{
    public double Value { get; private set; }

    public Length(double length)
    {
        Value = length;
    }

    public Length ToZero()
    {
        return new Length(0);
    }

    public Length GetNewLength(Length left, Length right)
    {
        return new Length(left.Value - right.Value);
    }
}