using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories;

public class EvilFighterFactory : ICreatureFactory
{
    private const int DefaultAttack = 1;

    private const int DefaultHealth = 6;

    public ICreatureBuilder Create(ICreatureBuilder builder)
    {
        return builder
            .WithAttack(new Attack(DefaultAttack))
            .WithHealth(new Health(DefaultHealth));
    }
}