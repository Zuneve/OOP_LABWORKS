using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public abstract class PathBase
{
    public Length PathLength { get; set; }

    protected PathBase(Length pathLength)
    {
        PathLength = pathLength;
    }

    public abstract SegmentResult TryPassPath(TrainInfo trainInfo);

    protected SegmentResult CheckSpeed(TrainInfo trainInfo)
    {
        var length = new Length(trainInfo.TrainSpeed.Value * trainInfo.PathAccuracy.Value);

        return trainInfo.TrainSpeed.Value <= 0 ?
            new SegmentResult.Failed()
            : new SegmentResult.Success(new Time(length.Value / trainInfo.TrainSpeed.Value), length);
    }
}
