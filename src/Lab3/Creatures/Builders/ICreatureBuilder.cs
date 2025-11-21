using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public interface ICreatureBuilder
{
    ICreatureBuilder WithAttack(Attack attack);

    ICreatureBuilder WithHealth(Health health);

    ICreatureBuilder WithModifier(IModifierFactory modifierFactory);

    ICreature Build();
}