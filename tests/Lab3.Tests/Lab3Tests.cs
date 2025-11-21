using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Lab3Tests
{
    // TODO: arrange, act, assert
    [Fact]
    public void Run_ShouldReturnSuccess_When_Creature_Has_TwoMagicShields_And_Take_HugeDamage()
    {
        var builder = new CombatAnalystBuilder();
        var director = new CombatAnalystDirector();
        ICreature creature = director.Direct(builder)
            .WithModifier(new MagicShieldModifierFactory())
            .WithModifier(new MagicShieldModifierFactory())
            .Build();

        creature.TakeDamage(new Attack(10000000));
        creature.TakeDamage(new Attack(10000000));

        Assert.Equal(4, creature.CreatureHealth.Value);

        creature.TakeDamage(new Attack(3));

        Assert.Equal(1, creature.CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_AddCreature_CloneCreature()
    {
        var board = new PlayerBoard();
        var builder = new CombatAnalystBuilder();
        var director = new CombatAnalystDirector();
        ICreature creature = director.Direct(builder)
            .WithModifier(new MagicShieldModifierFactory())
            .WithModifier(new MagicShieldModifierFactory())
            .Build();

        board.AddCreature(creature);

        Assert.NotSame(creature, board.GetCreatures()[0]);
    }
}