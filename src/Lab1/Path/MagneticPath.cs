using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class MagneticPath : PathBase
{
    public MagneticPath(Length pathLength) : base(pathLength) { }

    public override SegmentResult TryPassPath(Train trainInfo)
    {
        trainInfo.UpdateTrainSpeed();
        return CheckSpeed(trainInfo);
    }
}
