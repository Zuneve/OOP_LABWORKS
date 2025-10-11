using Itmo.ObjectOrientedProgramming.Lab1.Attributes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultInfo;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    public Speed TrainSpeed { get; private set; }

    private readonly Accuracy _pathAccuracy;

    private readonly Mass _trainMass;

    private readonly MaxAllowedForce _trainMaxAllowedForce;

    private Acceleration _trainAcceleration;

    public Train(
        Accuracy accuracy,
        Mass mass,
        MaxAllowedForce maxAllowedForce)
    {
        _trainAcceleration = new Acceleration(0);
        _pathAccuracy = accuracy;
        _trainMass = mass;
        _trainMaxAllowedForce = maxAllowedForce;
        TrainSpeed = new Speed(0);
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

    public PathResult CalculatePathTime(Length pathLength)
    {
        var curLength = new Length(0);
        var totalTime = new TimeDuration(0);

        while (curLength.IsLessThan(pathLength))
        {
            UpdateTrainSpeed();
            SegmentResult result = CalculateSegmentResult();

            if (TrainSpeed.Value <= 0 || result is not SegmentResult.Success s)
            {
                return new PathResult.Failed();
            }

            curLength = new Length(s.SegmentLength.Value + curLength.Value);
            totalTime = new TimeDuration(s.SegmentTimeDuration.Value + totalTime.Value);
        }

        return new PathResult.Success(totalTime);
    }

    private SegmentResult CalculateSegmentResult()
    {
        var length = new Length(TrainSpeed.Value * _pathAccuracy.Value);

        return TrainSpeed.Value <= 0
            ? new SegmentResult.Failed()
            : new SegmentResult.Success(new TimeDuration(length.Value / TrainSpeed.Value), length);
    }

    private void UpdateTrainSpeed()
    {
        TrainSpeed = TrainSpeed.Create(_trainAcceleration, _pathAccuracy);
    }
}