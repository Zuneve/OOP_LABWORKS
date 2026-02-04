using Itmo.ObjectOrientedProgramming.Lab1.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

public abstract record PathResult
{
    private PathResult() { }

    public sealed record Success(TimeDuration PathTimeDurationResult) : PathResult;

    public sealed record Failed : PathResult;
}