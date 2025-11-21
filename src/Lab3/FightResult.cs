namespace Itmo.ObjectOrientedProgramming.Lab3;

public enum FightOutcome
{
    Draw,
    FirstWin,
    FirstLose,
}

public abstract record FightResult
{
    private FightResult() { }

    public sealed record Success(FightOutcome Outcome) : FightResult;

    public sealed record Failed() : FightResult;
}