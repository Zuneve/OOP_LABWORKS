using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public MagicMirror() { }

    public ICreature ApplySpell(ICreature creature)
    {
        if (creature.CreatureAttack == null || creature.CreatureHealth == null)
        {
            throw new InvalidOperationException();
        }

        int creatureDamage = creature.CreatureAttack.Value;
        creature.ChangeAttack(new Attack(creature.CreatureHealth.Value));
        creature.ChangeHealth(new Health(creatureDamage));
        return creature;
    }
}