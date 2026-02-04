namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record Acceleration
{
    public double Value { get; }

    public Acceleration(double acceleration)
    {
        Value = acceleration;
    }

    public Acceleration Create(Force force, Mass mass)
    {
        return new Acceleration(force.Value / mass.Value);
    }
}