using Itmo.ObjectOrientedProgramming.Lab3.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public class ImmortalHorrorBuilder : BaseCreatureBuilder
{
    protected override ICreature CreateCreature(Attack attack, Health health)
    {
        return new ImmortalHorror(attack, health);
    }
}