using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class Station : PathBase
{
    private Time StopTime { get; }

    private MaxAllowedSpeed StationMaxAllowedSpeed { get; }

    public Station(Length pathLength, Time stopTime, MaxAllowedSpeed maxAllowedSpeed)
        : base(pathLength)
    {
        StopTime = stopTime;
        StationMaxAllowedSpeed = maxAllowedSpeed;
    }

    public override SegmentResult TryPassPath(TrainInfo trainInfo)
    {
        // If the speed is valid, the path will be 0, otherwise we return failed (in this case, we don't care about the path length)
        PathLength.ToZero();
        return trainInfo.TrainSpeed.Value > StationMaxAllowedSpeed.Value ?
              new SegmentResult.Failed()
            : new SegmentResult.Success(new Time(StopTime.Value), PathLength);
    }
}