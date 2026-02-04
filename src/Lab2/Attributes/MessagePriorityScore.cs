namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public record MessagePriorityScore
{
    public int Value { get; }

    public MessagePriorityScore(int priorityScore)
    {
        Value = priorityScore;
    }
}