namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record MaxAllowedForce
{
    public double Value { get; }

    public MaxAllowedForce(double maxAllowedForce)
    {
        Value = maxAllowedForce;
    }
}