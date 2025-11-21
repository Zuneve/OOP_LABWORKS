using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

public class MagicShieldModifierFactory : IModifierFactory
{
    public ICreature ApplyModifier(ICreature creature)
    {
        return new MagicShieldModifier(creature);
    }
}