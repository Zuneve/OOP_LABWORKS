using Itmo.ObjectOrientedProgramming.Lab3.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class EvilFighter : ICreature
{
    private const int AttackMultiplier = 2;

    public Attack CreatureAttack { get; private set; }

    public Health CreatureHealth { get; private set; }

    public EvilFighter(Attack attack, Health health)
    {
        CreatureAttack = attack;
        CreatureHealth = health;
    }

    public void AttackCreature(ICreature creature)
    {
        creature.TakeDamage(CreatureAttack);
    }

    public void TakeDamage(Attack attack)
    {
        ChangeHealth(new Health(CreatureHealth.Value - attack.Value));
        if (CreatureHealth.Value > 0)
        {
            CreatureAttack = new Attack(CreatureAttack.Value * AttackMultiplier);
        }
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
        return new EvilFighter(
            new Attack(CreatureAttack.Value),
            new Health(CreatureHealth.Value));
    }
}