using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;

public class CombatAnalystDirector : ICreatureDirector
{
    private const int DefaultAttack = 2;

    private const int DefaultHealth = 4;

    public ICreatureBuilder Direct(ICreatureBuilder builder)
    {
        return builder
            .WithAttack(new Attack(DefaultAttack))
            .WithHealth(new Health(DefaultHealth));
    }
}