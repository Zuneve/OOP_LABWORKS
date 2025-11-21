using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class PlayerBoard
{
    private const int MaxCreaturesCount = 7;
    private readonly Collection<ICreature> _creatures;

    public PlayerBoard()
    {
        _creatures = new Collection<ICreature>();
    }

    public void AddCreature(ICreature creature)
    {
        if (_creatures.Count < MaxCreaturesCount)
        {
            _creatures.Add(creature.Clone());
        }
    }

    public ICreature ApplySpell(ISpell spell, ICreature creature)
    {
        return spell.ApplySpell(creature);
    }

    public ReadOnlyCollection<ICreature> GetCreatures()
    {
        return new ReadOnlyCollection<ICreature>(_creatures);
    }

    public PlayerBoard Clone()
    {
        var newBoard = new PlayerBoard();

        foreach (ICreature creature in _creatures)
        {
            newBoard.AddCreature(creature);
        }

        return newBoard;
    }
}