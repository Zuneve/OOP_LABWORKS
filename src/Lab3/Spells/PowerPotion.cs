using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class PowerPotion : ISpell
{
    private const int AddedPower = 5;

    public ICreature ApplySpell(ICreature creature)
    {
        creature.ChangeAttack(new Attack(creature.CreatureAttack.Value + AddedPower));
        return creature;
    }
}