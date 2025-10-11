using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class ForceMagneticPath : IPath
{
    private readonly Length _pathLength;

    private readonly Force _pathForce;

    public ForceMagneticPath(Length pathLength, Force pathForce)
    {
        _pathLength = pathLength;
        _pathForce = pathForce;
    }

    public PathResult TryPassPath(Train train)
    {
        if (!train.ApplyForceForTrain(_pathForce))
        {
            return new PathResult.Failed();
        }

        PathResult result = train.CalculatePathTime(_pathLength);

        if (!train.ApplyForceForTrain(new Force(0)))
        {
            return new PathResult.Failed();
        }

        return result;
    }
}
