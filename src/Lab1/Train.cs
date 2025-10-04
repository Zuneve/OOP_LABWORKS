using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.Path;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    public Speed TrainSpeed { get; private set; }

    private readonly Accuracy _pathAccuracy;

    private readonly Mass _trainMass;

    private readonly MaxAllowedForce _trainMaxAllowedForce;

    private readonly MaxAllowedSpeed _finalAllowedSpeed;

    private readonly IReadOnlyList<IPath> _pathList;

    private Acceleration _trainAcceleration;

    public Train(
        Accuracy accuracy,
        Mass mass,
        MaxAllowedForce maxAllowedForce,
        MaxAllowedSpeed finalAllowedSpeed,
        IReadOnlyList<IPath> pathList)
    {
        _trainAcceleration = new Acceleration(0);
        _pathAccuracy = accuracy;
        _trainMass = mass;
        _trainMaxAllowedForce = maxAllowedForce;
        TrainSpeed = new Speed(0);
        _finalAllowedSpeed = finalAllowedSpeed;
        _pathList = pathList;
    }

    public void UpdateTrainSpeed()
    {
        TrainSpeed = TrainSpeed.Create(_trainAcceleration, _pathAccuracy);
    }

    public bool ApplyForceForTrain(Force force)
    {
        if (force.Value > _trainMaxAllowedForce.Value)
        {
            return false;
        }

        _trainAcceleration = _trainAcceleration.Create(force, _trainMass);
        TrainSpeed = TrainSpeed.Create(_trainAcceleration, _pathAccuracy);
        return true;
    }

    public SegmentResult CalculateSegmentResult()
    {
        var length = new Length(TrainSpeed.Value * _pathAccuracy.Value);

        return TrainSpeed.Value <= 0
            ? new SegmentResult.Failed()
            : new SegmentResult.Success(new TimeDuration(length.Value / TrainSpeed.Value), length);
    }

    public SimulationResult Simulate()
    {
        var totalTime = new TimeDuration(0);

        foreach (IPath path in _pathList)
        {
            PathResult result = path.TryPassPath(this);
            if (result is not PathResult.Success s)
            {
                return new SimulationResult.Failed();
            }

            totalTime = new TimeDuration(s.PathTimeDurationResult.Value + totalTime.Value);
        }

        return TrainSpeed.Value <= _finalAllowedSpeed.Value
            ? new SimulationResult.Success(totalTime)
            : new SimulationResult.Failed();
    }
}