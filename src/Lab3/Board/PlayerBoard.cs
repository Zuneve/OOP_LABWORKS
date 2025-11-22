using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Board;

public class PlayerBoard
{
    private readonly Collection<ICreature> _creatures;

    private PlayerBoard(Collection<ICreature> creatures)
    {
        _creatures = creatures;
    }

    public class PlayerBoardBuilder : IBoardBuilder
    {
        private const int MaxCreaturesCount = 7;
        private readonly Collection<ICreature> _creatures = [];

        public IBoardBuilder AddCreature(ICreature creature)
        {
            if (_creatures.Count < MaxCreaturesCount)
            {
                _creatures.Add(creature);
            }

            return this;
        }

        public PlayerBoard Build()
        {
            var creatures = new Collection<ICreature>();

            foreach (ICreature creature in _creatures)
            {
                creatures.Add(creature.Clone());
            }

            return new PlayerBoard(creatures);
        }
    }

    public ICreature ApplySpell(ISpell spell, ICreature creature)
    {
        return spell.ApplySpell(creature);
    }

    public Collection<ICreature> GetCreatures()
    {
        return new Collection<ICreature>(_creatures);
    }

    public Collection<ICreature> GetAttackerCreatures()
    {
        var validAttackerCreatures = new Collection<ICreature>();

        foreach (ICreature creature in _creatures)
        {
            if (IsFighterValid(creature, true))
            {
                validAttackerCreatures.Add(creature);
            }
        }

        return validAttackerCreatures;
    }

    public Collection<ICreature> GetDefendingCreatures()
    {
        var validDefendingCreatures = new Collection<ICreature>();

        foreach (ICreature creature in _creatures)
        {
            if (IsFighterValid(creature, false))
            {
                validDefendingCreatures.Add(creature);
            }
        }

        return validDefendingCreatures;
    }

    public PlayerBoard Clone()
    {
        var creatures = new Collection<ICreature>();

        foreach (ICreature creature in _creatures)
        {
            creatures.Add(creature.Clone());
        }

        return new PlayerBoard(creatures);
    }

    private bool IsFighterValid(ICreature creature, bool isAttacker)
    {
        bool isDamageValid = !isAttacker || creature.CreatureAttack.Value > 0;
        bool isHealthValid = creature.CreatureHealth.Value > 0;
        return isDamageValid && isHealthValid;
    }
}