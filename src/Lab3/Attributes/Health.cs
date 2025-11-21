namespace Itmo.ObjectOrientedProgramming.Lab3.Attributes;

public record Health
{
    public int Value { get; }

    public Health(int health)
    {
        Value = health;
    }
}