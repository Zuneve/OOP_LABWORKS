using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

public class MagicShieldModifier : ICreature
{
    public Attack CreatureAttack => _inner.CreatureAttack;

    public Health CreatureHealth => _inner.CreatureHealth;

    private readonly ICreature _inner;

    private bool _isShieldUsed;

    public MagicShieldModifier(ICreature creature)
    {
        _inner = creature;
        _isShieldUsed = false;
    }

    private MagicShieldModifier(ICreature creature, bool isShieldUsed)
    {
        _inner = creature;
        _isShieldUsed = isShieldUsed;
    }

    public void AttackCreature(ICreature creature)
    {
        _inner.AttackCreature(creature);
    }

    public void TakeDamage(Attack attack)
    {
        if (_isShieldUsed)
        {
            _inner.TakeDamage(attack);
            return;
        }

        _isShieldUsed = true;
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
        return new MagicShieldModifier(_inner.Clone(), _isShieldUsed);
    }
}