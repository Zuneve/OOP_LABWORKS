using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.Path;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Route
{
    private readonly MaxAllowedSpeed _finalAllowedSpeed;

    private readonly IReadOnlyList<IPath> _pathList;

    public Route(
        MaxAllowedSpeed finalAllowedSpeed,
        IReadOnlyList<IPath> pathList)
    {
        _finalAllowedSpeed = finalAllowedSpeed;
        _pathList = pathList;
    }

    public SimulationResult Simulate(Train train)
    {
        var totalTime = new TimeDuration(0);

        foreach (IPath path in _pathList)
        {
            PathResult result = path.TryPassPath(train);
            if (result is not PathResult.Success s)
            {
                return new SimulationResult.Failed();
            }

            totalTime = new TimeDuration(s.PathTimeDurationResult.Value + totalTime.Value);
        }

        return train.TrainSpeed.Value <= _finalAllowedSpeed.Value
            ? new SimulationResult.Success(totalTime)
            : new SimulationResult.Failed();
    }
}