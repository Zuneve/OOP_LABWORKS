using Itmo.ObjectOrientedProgramming.Lab1.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Path;

public class MagneticPath : BaseMagneticPath
{
    public MagneticPath(Length pathLength) : base(pathLength) { }

    protected override bool ApplyEffect(Train train)
    {
        train.UpdateTrainSpeed();
        return true;
    }
}
