using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;

public class AmuletMasterFactory : ICreatureFactory
{
    private const int DefaultAttack = 5;

    private const int DefaultHealth = 2;

    public ICreatureBuilder Direct(ICreatureBuilder builder)
    {
        return builder
            .WithAttack(new Attack(DefaultAttack))
            .WithHealth(new Health(DefaultHealth))
            .WithModifier(new AttackMasteryModifierApplierFactory())
            .WithModifier(new MagicShieldModifierApplierFactory());
    }
}