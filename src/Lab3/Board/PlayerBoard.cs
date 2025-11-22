using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.Board;

public class PlayerBoard
{
    private readonly IList<ICreature> _creatures;

    private PlayerBoard(IList<ICreature> creatures)
    {
        _creatures = creatures;
    }

    public class PlayerBoardBuilder : IBoardBuilder
    {
        private const int MaxCreaturesCount = 7;
        private readonly IList<ICreature> _creatures = [];

        public IBoardBuilder AddCreature(ICreature creature)
        {
            if (_creatures.Count >= MaxCreaturesCount)
            {
                throw new ArgumentOutOfRangeException(nameof(creature));
            }

            _creatures.Add(creature);
            return this;
        }

        public PlayerBoard Build()
        {
            var creatures = new List<ICreature>();

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

    public IList<ICreature> GetAttackerCreatures()
    {
        return new List<ICreature>(
            _creatures.Where(creature => IsFighterValid(creature, true)).Select(c => c).ToList());
    }

    public IList<ICreature> GetDefendingCreatures()
    {
        return new List<ICreature>(
            _creatures.Where(creature => IsFighterValid(creature, false)).Select(c => c).ToList());
    }

    public PlayerBoard Clone()
    {
        var creatures = new List<ICreature>();

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