using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Board;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.RandomServices;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Lab3Tests
{
    [Fact]
    public void Run_ShouldReturnSuccess_When_Creature_Has_TwoMagicShields_And_Take_HugeDamageTwoTimes()
    {
        // arrange
        var builder = new CombatAnalystBuilder();
        var director = new CombatAnalystFactory();

        ICreature creature = director.Direct(builder)
            .WithModifier(new MagicShieldModifierApplierFactory())
            .WithModifier(new MagicShieldModifierApplierFactory())
            .Build();

        // act
        creature.TakeDamage(new Attack(10000000));
        creature.TakeDamage(new Attack(10000000));

        // assert
        Assert.Equal(4, creature.CreatureHealth.Value);

        // act
        creature.TakeDamage(new Attack(3));

        // assert
        Assert.Equal(1, creature.CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_AddCreature_CloneCreature()
    {
        // arrange
        var builder = new CombatAnalystBuilder();
        var director = new CombatAnalystFactory();

        ICreature creature = director.Direct(builder)
            .WithModifier(new MagicShieldModifierApplierFactory())
            .WithModifier(new MagicShieldModifierApplierFactory())
            .Build();

        // act
        PlayerBoard board = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature).Build();

        // assert
        Assert.NotSame(creature, board.GetAttackerCreatures()[0]);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_WhenFight_NotChangeOriginalBoardCreatures()
    {
        // arrange
        var builder1 = new MimicChestBuilder();
        var director1 = new MimicChestFactory();
        ICreature creature1 = director1.Direct(builder1).Build();

        var builder2 = new CombatAnalystBuilder();
        var director2 = new CombatAnalystFactory();
        ICreature creature2 = director2.Direct(builder2).Build();

        int originalAttack1 = creature1.CreatureAttack.Value;
        int originalHealth1 = creature1.CreatureHealth.Value;
        int originalAttack2 = creature2.CreatureAttack.Value;
        int originalHealth2 = creature2.CreatureHealth.Value;

        PlayerBoard board1 = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature1).Build();
        PlayerBoard board2 = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature2).Build();

        // act
        var fight = new Fight(board1, board2, new RandomService());
        fight.StartFight();

        // assert
        Assert.Equal(originalAttack1, board1.GetAttackerCreatures()[0].CreatureAttack.Value);
        Assert.Equal(originalHealth1, board1.GetAttackerCreatures()[0].CreatureHealth.Value);

        Assert.Equal(originalAttack2, board2.GetAttackerCreatures()[0].CreatureAttack.Value);
        Assert.Equal(originalHealth2, board2.GetAttackerCreatures()[0].CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_Changes_On_FirstPlayerBoard_NotChangeCreatures_On_SecondPlayerBoard()
    {
        // arrange
        var builder1 = new AmuletMasterBuilder();
        var director1 = new AmuletMasterFactory();
        ICreature creature1 = director1.Direct(builder1).Build();

        var builder2 = new AmuletMasterBuilder();
        var director2 = new AmuletMasterFactory();
        ICreature creature2 = director2.Direct(builder2).Build();

        PlayerBoard board1 = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature1).Build();
        PlayerBoard board2 = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature2).Build();

        // act
        board1.GetAttackerCreatures()[0].ChangeAttack(new Attack(10));

        // assert
        Assert.Equal(5, board2.GetAttackerCreatures()[0].CreatureAttack.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_Creature_With_AttackMasteryModifier_AttackTwice()
    {
        // arrange
        var builder1 = new MimicChestBuilder();
        var director1 = new MimicChestFactory();

        ICreature creature1 = director1.Direct(builder1)
            .WithModifier(new AttackMasteryModifierApplierFactory())
            .Build();

        var builder2 = new EvilFighterBuilder();
        var director2 = new EvilFighterFactory();

        ICreature creature2 = director2.Direct(builder2)
            .Build();

        // act
        creature1.AttackCreature(creature2);

        // assert
        Assert.Equal(3, creature2.CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_ImmortalHorror_DoesntDie_FirstTime()
    {
        // arrange
        var builder1 = new MimicChestBuilder();
        var director1 = new MimicChestFactory();

        ICreature creature1 = director1.Direct(builder1)
            .Build();

        var builder2 = new ImmortalHorrorBuilder();
        var director2 = new ImmortalHorrorFactory();

        ICreature creature2 = director2.Direct(builder2)
            .Build();

        // act
        creature1.AttackCreature(creature2);

        // assert
        Assert.Equal(1, creature2.CreatureHealth.Value);

        // act
        creature1.AttackCreature(creature2);

        // assert
        Assert.Equal(0, creature2.CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_AmuletMaster_With_Spells_Beats_CombatAnalyst()
    {
        // arrange
        var builder1 = new AmuletMasterBuilder();
        var director1 = new AmuletMasterFactory();
        ICreature creature1 = director1.Direct(builder1).Build();

        var builder2 = new CombatAnalystBuilder();
        var director2 = new CombatAnalystFactory();
        ICreature creature2 = director2.Direct(builder2).Build();

        PlayerBoard board1 = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature1).Build();
        PlayerBoard board2 = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature2).Build();

        board1.ApplySpell(new PowerPotion(), creature1);
        board1.ApplySpell(new PowerPotion(), creature1);
        board1.ApplySpell(new EndurancePotion(), creature1);
        board1.ApplySpell(new EndurancePotion(), creature1);

        // act
        var fight = new Fight(board1, board2, new RandomService());
        FightResult fightResult = fight.StartFight();

        // assert
        Assert.IsType<FightResult.FirstWin>(fightResult);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_EndurancePotion_IncreaseHealth()
    {
        // arrange
        var builder1 = new AmuletMasterBuilder();
        var director1 = new AmuletMasterFactory();
        ICreature creature1 = director1.Direct(builder1).Build();

        // act
        PlayerBoard board1 = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature1).Build();
        board1.ApplySpell(new EndurancePotion(), creature1);

        // assert
        Assert.Equal(7, creature1.CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_PowerPotion_IncreaseAttack()
    {
        // arrange
        var builder1 = new AmuletMasterBuilder();
        var director1 = new AmuletMasterFactory();
        ICreature creature1 = director1.Direct(builder1).Build();

        // act
        PlayerBoard board1 = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature1).Build();
        board1.ApplySpell(new PowerPotion(), creature1);

        // assert
        Assert.Equal(10, creature1.CreatureAttack.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_ProtectionAmulet_Applies_MagicShield_ToCreature()
    {
        // arrange
        var builder = new MimicChestBuilder();
        var director = new MimicChestFactory();
        ICreature creature = director.Direct(builder).Build();

        PlayerBoard board = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature).Build();
        creature = board.ApplySpell(new ProtectionAmulet(), creature);

        // act
        creature.TakeDamage(new Attack(10000000));

        // assert
        Assert.Equal(1, creature.CreatureHealth.Value);

        // act
        creature.TakeDamage(new Attack(3));

        // assert
        Assert.Equal(0, creature.CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_MagicMirror_Swap_HealthAndAttack()
    {
        // arrange
        var builder = new MimicChestBuilder();
        var director = new MimicChestFactory();
        ICreature creature = director.Direct(builder).Build();

        int oldAttack = creature.CreatureAttack.Value;
        int oldHealth = creature.CreatureHealth.Value;

        PlayerBoard board = new PlayerBoard.PlayerBoardBuilder().AddCreature(creature).Build();

        // act
        board.ApplySpell(new MagicMirror(), creature);

        // assert
        Assert.Equal(oldHealth, creature.CreatureAttack.Value);
        Assert.Equal(oldAttack, creature.CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_8thCreature_NotAdded_ToBoard()
    {
        // arrange
        var creature1 = new MimicChest(new Attack(1), new Health(1));
        var creature2 = new MimicChest(new Attack(1), new Health(1));
        var creature3 = new MimicChest(new Attack(1), new Health(1));
        var creature4 = new MimicChest(new Attack(1), new Health(1));
        var creature5 = new MimicChest(new Attack(1), new Health(1));
        var creature6 = new MimicChest(new Attack(1), new Health(1));
        var creature7 = new MimicChest(new Attack(1), new Health(1));
        var creature8 = new MimicChest(new Attack(1), new Health(1));

        // act
        IBoardBuilder builder = new PlayerBoard.PlayerBoardBuilder()
            .AddCreature(creature1)
            .AddCreature(creature2)
            .AddCreature(creature3)
            .AddCreature(creature4)
            .AddCreature(creature5)
            .AddCreature(creature6)
            .AddCreature(creature7);

        // assert
        Assert.Throws<ArgumentOutOfRangeException>(() => builder.AddCreature(creature8));
    }
}