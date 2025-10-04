using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.Path;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class TrainSimulator
{
    private readonly Train _train;

    private readonly IReadOnlyList<PathBase> _pathList;

    private readonly MaxAllowedSpeed _finalAllowedSpeed;

    public TrainSimulator(
        Train train,
        IReadOnlyList<PathBase> pathList,
        MaxAllowedSpeed finalAllowedSpeed)
    {
        _train = train;
        _pathList = pathList;
        _finalAllowedSpeed = finalAllowedSpeed;
    }

    public SimulationResult Simulate()
    {
        double totalLength = _pathList.Sum(segment => segment.PathLength.Value);
        int listSize = _pathList.Count;
        int curIndex = 0;
        var totalTime = new TimeDuration(0);

        for (double i = 0; i < totalLength / _train.PathAccuracy.Value; i++)
        {
            if (_pathList[curIndex].PathLength.Value <= 0)
            {
                curIndex++;
            }

            if (curIndex >= listSize)
            {
                break;
            }

            SegmentResult result = _pathList[curIndex].TryPassPath(_train);
            if (result is not SegmentResult.Success s) return new SimulationResult.Failed();
            totalTime = new TimeDuration(s.SegmentTimeDuration.Value + totalTime.Value);
            _pathList[curIndex].PathLength =
                new Length(_pathList[curIndex].PathLength.Value - s.SegmentLength.Value);
        }

        bool lastPathPassed = _pathList.Count == 0 || _pathList[^1].PathLength.Value <= 0;
        bool successPath = (curIndex >= listSize) &&
                           lastPathPassed &&
                           _train.TrainSpeed.Value <= _finalAllowedSpeed.Value;

        return successPath
            ? new SimulationResult.Success(totalTime)
            : new SimulationResult.Failed();
    }
}