using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

public interface IModifierFactory
{
    ICreature ApplyModifier(ICreature creature);
}