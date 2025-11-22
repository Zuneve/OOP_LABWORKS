using Itmo.ObjectOrientedProgramming.Lab3.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class ImmortalHorror : ICreature
{
    private bool _wasDead;

    public Attack CreatureAttack { get; private set; }

    public Health CreatureHealth { get; private set; }

    public ImmortalHorror(Attack attack, Health health)
    {
        _wasDead = false;
        CreatureAttack = attack;
        CreatureHealth = health;
    }

    private ImmortalHorror(Attack attack, Health health, bool wasDead)
    {
        _wasDead = wasDead;
        CreatureAttack = attack;
        CreatureHealth = health;
    }

    public void AttackCreature(ICreature creature)
    {
        creature.TakeDamage(CreatureAttack);
    }

    public void TakeDamage(Attack attack)
    {
        CreatureHealth = new Health(CreatureHealth.Value - attack.Value);

        if (_wasDead || CreatureHealth.Value > 0)
        {
            return;
        }

        CreatureHealth = new Health(1);
        _wasDead = true;
    }

    public void ChangeHealth(Health newHealth)
    {
        CreatureHealth = newHealth;
    }

    public void ChangeAttack(Attack newAttack)
    {
        CreatureAttack = newAttack;
    }

    public ICreature Clone()
    {
        return new ImmortalHorror(
            new Attack(CreatureAttack.Value),
            new Health(CreatureHealth.Value),
            _wasDead);
    }
}