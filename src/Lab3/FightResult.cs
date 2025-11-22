namespace Itmo.ObjectOrientedProgramming.Lab3;

public abstract record FightResult
{
    private FightResult() { }

    public sealed record Draw : FightResult;

    public sealed record FirstWin : FightResult;

    public sealed record SecondWin : FightResult;

    public sealed record Failed() : FightResult;
}