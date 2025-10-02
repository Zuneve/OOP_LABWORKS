using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.Path;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1.Train;

public class TrainSimulator
{
    private readonly TrainInfo _train;

    private readonly IReadOnlyList<PathBase> _pathList;

    private readonly MaxAllowedSpeed _finalAllowedSpeed;

    public TrainSimulator(
        TrainInfo train,
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
        bool successPath = true;
        var totalTime = new Time(0);

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

            if (result is SegmentResult.Success s)
            {
                totalTime = new Time(s.SegmentTime.Value + totalTime.Value);
                _pathList[curIndex].PathLength =
                    new Length(_pathList[curIndex].PathLength.Value - s.SegmentLength.Value);
            }
            else
            {
                successPath = false;
                break;
            }
        }

        bool lastPathPassed = _pathList.Count == 0 || _pathList[^1].PathLength.Value <= 0;
        successPath &= (curIndex >= listSize) && lastPathPassed;
        successPath &= _train.TrainSpeed.Value <= _finalAllowedSpeed.Value;

        return successPath
            ? new SimulationResult.Success(totalTime)
            : new SimulationResult.Failed();
    }
}