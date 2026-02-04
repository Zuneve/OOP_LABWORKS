namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record Force
{
    public double Value { get; }

    public Force(double force)
    {
        Value = force;
    }
}