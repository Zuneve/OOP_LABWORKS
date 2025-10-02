using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;
using Itmo.ObjectOrientedProgramming.Lab1.Train;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class ForceMagneticPath : PathBase
{
    private Force PathForce { get; }

    public ForceMagneticPath(Length pathLength, Force force) : base(pathLength)
    {
        PathForce = force;
    }

    public override SegmentResult TryPassPath(TrainInfo trainInfo)
    {
        trainInfo.ApplyForceForTrain(PathForce);
        return CheckSpeed(trainInfo);
    }
}
