using Itmo.ObjectOrientedProgramming.Lab3.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    Attack CreatureAttack { get; }

    Health CreatureHealth { get; }

    void AttackCreature(ICreature creature);

    void TakeDamage(Attack attack);

    void ChangeHealth(Health newHealth);

    void ChangeAttack(Attack newAttack);

    ICreature Clone();
}