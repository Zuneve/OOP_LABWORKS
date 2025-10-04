using Itmo.ObjectOrientedProgramming.Lab1.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

public abstract record SimulationResult
{
    private SimulationResult() { }

    public sealed record Success(TimeDuration TimeDurationResult) : SimulationResult;

    public sealed record Failed : SimulationResult;
}