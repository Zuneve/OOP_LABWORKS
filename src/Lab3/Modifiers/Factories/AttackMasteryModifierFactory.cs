using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

public class AttackMasteryModifierFactory : IModifierFactory
{
    public ICreature ApplyModifier(ICreature creature)
    {
        return new AttackMasteryModifier(creature);
    }
}