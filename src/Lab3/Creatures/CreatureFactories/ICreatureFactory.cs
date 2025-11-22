using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.CreatureFactories;

public interface ICreatureFactory
{
    ICreatureBuilder Create(ICreatureBuilder builder);
}