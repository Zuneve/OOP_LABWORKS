using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public class ImmortalHorrorBuilder : BaseCreatureBuilder
{
    public override ICreature Build()
    {
        if (CreatureAttack is null || CreatureHealth is null)
        {
            throw new ArgumentNullException();
        }

        ICreature creature = new ImmortalHorror(CreatureAttack, CreatureHealth);

        foreach (IModifierFactory modifierFactory in ModifierFactories)
        {
            creature = modifierFactory.ApplyModifier(creature);
        }

        return creature;
    }
}