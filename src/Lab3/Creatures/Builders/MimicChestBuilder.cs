using Itmo.ObjectOrientedProgramming.Lab3.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public class MimicChestBuilder : BaseCreatureBuilder
{
    protected override ICreature CreateCreature(Attack attack, Health health)
    {
        return new MimicChest(attack, health);
    }
}