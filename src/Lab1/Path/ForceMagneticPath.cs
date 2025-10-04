using Itmo.ObjectOrientedProgramming.Lab1.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class ForceMagneticPath : BaseMagneticPath
{
    private readonly Force _pathForce;

    public ForceMagneticPath(Length pathLength, Force pathForce) : base(pathLength)
    {
        _pathForce = pathForce;
    }

    protected override bool ApplyEffect(Train train)
    {
        return train.ApplyForceForTrain(_pathForce);
    }
}
