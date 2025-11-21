using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;

public class MimicChestDirector : ICreatureDirector
{
    private const int DefaultAttack = 1;

    private const int DefaultHealth = 1;

    public ICreatureBuilder Direct(ICreatureBuilder builder)
    {
        return builder
            .WithAttack(new Attack(DefaultAttack))
            .WithHealth(new Health(DefaultHealth));
    }
}