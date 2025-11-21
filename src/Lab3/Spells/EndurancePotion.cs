using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class EndurancePotion : ISpell
{
    private const int AddedHealth = 5;

    public EndurancePotion() { }

    public ICreature ApplySpell(ICreature creature)
    {
        if (creature.CreatureHealth == null)
        {
            throw new InvalidOperationException();
        }

        creature.ChangeHealth(new Health(creature.CreatureHealth.Value + AddedHealth));
        return creature;
    }
}