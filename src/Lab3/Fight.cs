using Itmo.ObjectOrientedProgramming.Lab3.Board;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Fight
{
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
            Collection<ICreature> validFightersFirstPlayer;
            Collection<ICreature> validFightersSecondPlayer;

            if (isFirstPlayerTurn)
            {
                validFightersFirstPlayer = _firstPlayerBoard.GetAttackerCreatures();
                validFightersSecondPlayer = _secondPlayerBoard.GetDefendingCreatures();
            }
            else
            {
                validFightersFirstPlayer = _firstPlayerBoard.GetDefendingCreatures();
                validFightersSecondPlayer = _secondPlayerBoard.GetAttackerCreatures();
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
}