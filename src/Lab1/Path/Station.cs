using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class Station : IPath
{
    private readonly TimeDuration _stopTimeDuration;

    private readonly MaxAllowedSpeed _stationMaxAllowedSpeed;

    public Station(TimeDuration stopTimeDuration, MaxAllowedSpeed maxAllowedSpeed)
    {
        _stopTimeDuration = stopTimeDuration;
        _stationMaxAllowedSpeed = maxAllowedSpeed;
    }

    public PathResult TryPassPath(Train trainInfo)
    {
        if (trainInfo.TrainSpeed.Value > _stationMaxAllowedSpeed.Value)
        {
            return new PathResult.Failed();
        }

        return new PathResult.Success(new TimeDuration(_stopTimeDuration.Value));
    }
}