using Itmo.ObjectOrientedProgramming.Lab3.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : ICreature
{
    public Attack CreatureAttack { get; private set; }

    public Health CreatureHealth { get; private set; }

    public MimicChest(Attack attack, Health health)
    {
        CreatureAttack = attack;
        CreatureHealth = health;
    }

    public void AttackCreature(ICreature creature)
    {
        CreatureAttack = new Attack(
            Math.Max(creature.CreatureAttack.Value, CreatureAttack.Value));
        CreatureHealth = new Health(
            Math.Max(creature.CreatureHealth.Value, CreatureHealth.Value));
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
        return new MimicChest(
            new Attack(CreatureAttack.Value),
            new Health(CreatureHealth.Value));
    }
}