using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

public interface IModifierApplierFactory
{
    ICreature ApplyModifier(ICreature creature);
}