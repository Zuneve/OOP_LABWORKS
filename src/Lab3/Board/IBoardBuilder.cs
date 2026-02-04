using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Board;

public interface IBoardBuilder
{
    IBoardBuilder AddCreature(ICreature creature);

    PlayerBoard Build();
}