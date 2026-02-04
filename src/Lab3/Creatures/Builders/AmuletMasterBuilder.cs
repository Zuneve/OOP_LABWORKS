using Itmo.ObjectOrientedProgramming.Lab3.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public class AmuletMasterBuilder : BaseCreatureBuilder
{
    protected override ICreature CreateCreature(Attack attack, Health health)
    {
        return new AmuletMaster(attack, health);
    }
}