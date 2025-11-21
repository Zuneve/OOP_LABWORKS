using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class EndurancePotion : ISpell
{
    private const int AddedHealth = 5;

    public ICreature ApplySpell(ICreature creature)
    {
        creature.ChangeHealth(new Health(creature.CreatureHealth.Value + AddedHealth));
        return creature;
    }
}