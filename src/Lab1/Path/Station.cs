using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class Station : IPath
{
    private TimeDuration StopTimeDuration { get; }

    private MaxAllowedSpeed StationMaxAllowedSpeed { get; }

    public Station(TimeDuration stopTimeDuration, MaxAllowedSpeed maxAllowedSpeed)
    {
        StopTimeDuration = stopTimeDuration;
        StationMaxAllowedSpeed = maxAllowedSpeed;
    }

    public PathResult TryPassPath(Train trainInfo)
    {
        if (trainInfo.TrainSpeed.Value > StationMaxAllowedSpeed.Value)
        {
            return new PathResult.Failed();
        }

        return new PathResult.Success(new TimeDuration(StopTimeDuration.Value));
    }
}