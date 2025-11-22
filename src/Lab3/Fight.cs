using Itmo.ObjectOrientedProgramming.Lab3.Board;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.RandomServices;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Fight
{
    private readonly PlayerBoard _firstPlayerBoard;

    private readonly PlayerBoard _secondPlayerBoard;

    public Fight(PlayerBoard firstPlayerBoard, PlayerBoard secondPlayerBoard, IRandomService randomService)
    {
        _firstPlayerBoard = firstPlayerBoard.Clone();
        _secondPlayerBoard = secondPlayerBoard.Clone();
    }

    public FightResult StartFight()
    {
        bool isFirstPlayerTurn = true;
        bool isGameFinished = false;

        while (!isGameFinished)
        {
            IList<ICreature> validFightersFirstPlayer;
            IList<ICreature> validFightersSecondPlayer;

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
                return validFightersFirstPlayer.Count == 0 && validFightersSecondPlayer.Count == 0
                    ? new FightResult.Draw()
                    : validFightersFirstPlayer.Count == 0
                        ? new FightResult.SecondWin()
                        : new FightResult.FirstWin();
            }

            ICreature firstPlayerCreature = _firstPlayerBoard.GetRandomFighter(validFightersFirstPlayer);
            ICreature secondPlayerCreature = _secondPlayerBoard.GetRandomFighter(validFightersSecondPlayer);

            firstPlayerCreature.AttackCreature(secondPlayerCreature);
            isFirstPlayerTurn = !isFirstPlayerTurn;
        }

        return new FightResult.Failed();
    }
}