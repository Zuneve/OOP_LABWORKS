using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class MagneticPath : IPath
{
    private readonly Length _pathLength;

    public MagneticPath(Length pathLength)
    {
        _pathLength = pathLength;
    }

    public PathResult TryPassPath(Train train)
    {
        return train.CalculatePathTime(_pathLength);
    }
}
