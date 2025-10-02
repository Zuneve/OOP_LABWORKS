using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class MagneticPath : PathBase
{
    public MagneticPath(Length pathLength) : base(pathLength) { }

    public override SegmentResult TryPassPath(TrainInfo trainInfo)
    {
        trainInfo.UpdateTrainSpeed();
        return CheckSpeed(trainInfo);
    }
}
