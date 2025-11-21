using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Fight
{
    // TODO : Change ICreature to their directors
    private readonly PlayerBoard _firstPlayerBoard;

    private readonly PlayerBoard _secondPlayerBoard;

    private readonly RandomService _randomService;

    public Fight(PlayerBoard firstPlayerBoard, PlayerBoard secondPlayerBoard)
    {
        _firstPlayerBoard = firstPlayerBoard.Clone();
        _secondPlayerBoard = secondPlayerBoard.Clone();
        _randomService = new RandomService();
    }

    public FightResult StartFight()
    {
        bool isFirstPlayerTurn = _randomService.GetNext(0, 1) == 0;
        bool isGameFinished = false;

        while (!isGameFinished)
        {
            var validFightersFirstPlayer = new List<ICreature>();
            var validFightersSecondPlayer = new List<ICreature>();

            foreach (ICreature creature in _firstPlayerBoard.GetCreatures())
            {
                if (IsFighterValid(creature, isFirstPlayerTurn))
                {
                    validFightersFirstPlayer.Add(creature);
                }
            }

            foreach (ICreature creature in _secondPlayerBoard.GetCreatures())
            {
                if (IsFighterValid(creature, !isFirstPlayerTurn))
                {
                    validFightersSecondPlayer.Add(creature);
                }
            }

            isGameFinished = validFightersFirstPlayer.Count == 0 || validFightersSecondPlayer.Count == 0;

            if (isGameFinished)
            {
                return new FightResult.Success(
                    validFightersFirstPlayer.Count == 0 && validFightersSecondPlayer.Count == 0
                        ? FightOutcome.Draw
                        : validFightersFirstPlayer.Count == 0 ?
                            FightOutcome.FirstLose
                            : FightOutcome.FirstWin);
            }

            int firstPlayerFighterIndex = _randomService.GetNext(0, validFightersFirstPlayer.Count);
            int secondPlayerFighterIndex = _randomService.GetNext(0, validFightersSecondPlayer.Count);

            ICreature firstPlayerCreature = validFightersFirstPlayer[firstPlayerFighterIndex];
            ICreature secondPlayerCreature = validFightersSecondPlayer[secondPlayerFighterIndex];

            firstPlayerCreature.AttackCreature(secondPlayerCreature);
            isFirstPlayerTurn = !isFirstPlayerTurn;
        }

        return new FightResult.Failed();
    }

    private bool IsFighterValid(ICreature creature, bool isAttacker)
    {
        bool isDamageValid = !isAttacker || creature.CreatureAttack.Value > 0;
        bool isHealthValid = creature.CreatureHealth.Value > 0;
        return isDamageValid && isHealthValid;
    }
}