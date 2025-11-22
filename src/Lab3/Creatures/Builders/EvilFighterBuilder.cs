using Itmo.ObjectOrientedProgramming.Lab3.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public class EvilFighterBuilder : BaseCreatureBuilder
{
    protected override ICreature CreateCreature(Attack attack, Health health)
    {
        return new EvilFighter(attack, health);
    }
}