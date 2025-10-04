using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public abstract class BaseMagneticPath : IPath
{
    private readonly Length _pathLength;

    protected BaseMagneticPath(Length pathLength)
    {
        _pathLength = pathLength;
    }

    public PathResult TryPassPath(Train trainInfo)
    {
        var curLength = new Length(0);
        var totalTime = new TimeDuration(0);

        while (curLength.Value < _pathLength.Value)
        {
            bool applied = ApplyEffect(trainInfo);
            if (!applied)
            {
                return new PathResult.Failed();
            }

            SegmentResult result = trainInfo.CalculateSegmentResult();
            if (result is not SegmentResult.Success s)
            {
                return new PathResult.Failed();
            }

            curLength = new Length(s.SegmentLength.Value + curLength.Value);
            totalTime = new TimeDuration(s.SegmentTimeDuration.Value + totalTime.Value);
        }

        return new PathResult.Success(totalTime);
    }

    protected abstract bool ApplyEffect(Train train);
}