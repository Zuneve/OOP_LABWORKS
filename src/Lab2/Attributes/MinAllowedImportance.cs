namespace Itmo.ObjectOrientedProgramming.Lab2.Attributes;

public record MinAllowedImportance
{
    public int Value { get; }

    public MinAllowedImportance(int minAllowedImportance)
    {
        Value = minAllowedImportance;
    }
}