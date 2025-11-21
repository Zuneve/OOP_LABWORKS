using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class PowerPotion : ISpell
{
    private const int AddedPower = 5;

    public PowerPotion() { }

    public ICreature ApplySpell(ICreature creature)
    {
        if (creature.CreatureAttack == null)
        {
            throw new InvalidOperationException();
        }

        creature.ChangeAttack(new Attack(creature.CreatureAttack.Value + AddedPower));
        return creature;
    }
}