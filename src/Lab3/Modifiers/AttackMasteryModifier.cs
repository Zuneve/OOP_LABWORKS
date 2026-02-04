using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class AttackMasteryModifier : ICreature
{
    public Attack CreatureAttack => _inner.CreatureAttack;

    public Health CreatureHealth => _inner.CreatureHealth;

    private readonly ICreature _inner;

    public AttackMasteryModifier(ICreature creature)
    {
        _inner = creature;
    }

    public void AttackCreature(ICreature creature)
    {
        _inner.AttackCreature(creature);
        if (creature.CreatureHealth.Value > 0)
        {
            _inner.AttackCreature(creature);
        }
    }

    public void TakeDamage(Attack attack)
    {
        _inner.TakeDamage(attack);
    }

    public void ChangeHealth(Health newHealth)
    {
        _inner.ChangeHealth(newHealth);
    }

    public void ChangeAttack(Attack newAttack)
    {
        _inner.ChangeAttack(newAttack);
    }

    public ICreature Clone()
    {
        return new AttackMasteryModifier(_inner.Clone());
    }
}