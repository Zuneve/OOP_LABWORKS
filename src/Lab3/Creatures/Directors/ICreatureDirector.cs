using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;

public interface ICreatureDirector
{
    ICreatureBuilder Direct(ICreatureBuilder builder);
}