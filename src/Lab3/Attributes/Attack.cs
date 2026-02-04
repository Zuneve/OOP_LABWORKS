namespace Itmo.ObjectOrientedProgramming.Lab3.Attributes;

public record Attack
{
    public int Value { get; }

    public Attack(int attack)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(attack);
        Value = attack;
    }
}