using Itmo.ObjectOrientedProgramming.Lab1.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    public Accuracy PathAccuracy { get; }

    public Speed TrainSpeed { get; private set; }

    private Acceleration TrainAcceleration { get; set; }

    private Mass TrainMass { get; }

    private MaxAllowedForce TrainMaxAllowedForce { get; }

    public Train(
        Accuracy accuracy,
        Mass mass,
        MaxAllowedForce maxAllowedForce)
    {
        TrainAcceleration = new Acceleration(0);
        PathAccuracy = accuracy;
        TrainMass = mass;
        TrainMaxAllowedForce = maxAllowedForce;
        TrainSpeed = new Speed(0);
    }

    public void UpdateTrainSpeed()
    {
        TrainSpeed = TrainSpeed.Create(TrainAcceleration, PathAccuracy);
    }

    public bool ApplyForceForTrain(Force force)
    {
        if (force.Value > TrainMaxAllowedForce.Value)
        {
            return false;
        }

        TrainAcceleration = TrainAcceleration.Create(force, TrainMass);
        TrainSpeed = TrainSpeed.Create(TrainAcceleration, PathAccuracy);
        return true;
    }
}