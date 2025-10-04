using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class Station : PathBase
{
    private TimeDuration StopTimeDuration { get; }

    private MaxAllowedSpeed StationMaxAllowedSpeed { get; }

    public Station(Length pathLength, TimeDuration stopTimeDuration, MaxAllowedSpeed maxAllowedSpeed)
        : base(pathLength)
    {
        StopTimeDuration = stopTimeDuration;
        StationMaxAllowedSpeed = maxAllowedSpeed;
    }

    public override SegmentResult TryPassPath(Train trainInfo)
    {
        PathLength.ToZero();
        if (trainInfo.TrainSpeed.Value > StationMaxAllowedSpeed.Value)
        {
            return new SegmentResult.Failed();
        }

        return new SegmentResult.Success(new TimeDuration(StopTimeDuration.Value), PathLength);
    }
}