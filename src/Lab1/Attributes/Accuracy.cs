namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record Accuracy
{
    public double Value { get; }

    public Accuracy(double accuracy)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(accuracy);
        Value = accuracy;
    }
}