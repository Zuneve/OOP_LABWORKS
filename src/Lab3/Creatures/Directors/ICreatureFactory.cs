using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;

public interface ICreatureFactory
{
    ICreatureBuilder Direct(ICreatureBuilder builder);
}