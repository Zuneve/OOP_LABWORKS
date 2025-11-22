using Itmo.ObjectOrientedProgramming.Lab3.Board;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.RandomServices;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Fight
{
    private readonly PlayerBoard _firstPlayerBoard;

    private readonly PlayerBoard _secondPlayerBoard;

    private readonly IRandomService _randomService;

    public Fight(PlayerBoard firstPlayerBoard, PlayerBoard secondPlayerBoard, IRandomService randomService)
    {
        _firstPlayerBoard = firstPlayerBoard.Clone();
        _secondPlayerBoard = secondPlayerBoard.Clone();
        _randomService = new RandomService();
        _randomService = randomService;
    }

    public FightResult StartFight()
    {
        bool isFirstPlayerTurn = _randomService.GetNext(0, 1) == 0;
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

            ICreature firstPlayerCreature = GetRandomFighter(validFightersFirstPlayer);
            ICreature secondPlayerCreature = GetRandomFighter(validFightersSecondPlayer);

            firstPlayerCreature.AttackCreature(secondPlayerCreature);
            isFirstPlayerTurn = !isFirstPlayerTurn;
        }

        return new FightResult.Failed();
    }

    private ICreature GetRandomFighter(IList<ICreature> creatures)
    {
        int fighterIndex = _randomService.GetNext(0, creatures.Count);
        return creatures[fighterIndex];
    }
}