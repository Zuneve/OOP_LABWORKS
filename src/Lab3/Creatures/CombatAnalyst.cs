using Itmo.ObjectOrientedProgramming.Lab3.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CombatAnalyst : ICreature
{
    private const int AddedPower = 2;

    public Attack CreatureAttack { get; private set; }

    public Health CreatureHealth { get; private set; }

    public CombatAnalyst(Attack attack, Health health)
    {
        CreatureAttack = attack;
        CreatureHealth = health;
    }

    public void AttackCreature(ICreature creature)
    {
        CreatureAttack = new Attack(CreatureAttack.Value + AddedPower);

        creature.TakeDamage(CreatureAttack);
    }

    public void TakeDamage(Attack attack)
    {
        CreatureHealth = new Health(CreatureHealth.Value - attack.Value);
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
        return new CombatAnalyst(
            new Attack(CreatureAttack.Value),
            new Health(CreatureHealth.Value));
    }
}