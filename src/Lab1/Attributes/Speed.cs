namespace Itmo.ObjectOrientedProgramming.Lab1.Attributes;

public record Speed
{
    public double Value { get; }

    public Speed(double speed)
    {
        Value = speed;
    }

    public Speed Create(Acceleration acceleration, Accuracy accuracy)
    {
        return new Speed(Value + (acceleration.Value * accuracy.Value));
    }
}