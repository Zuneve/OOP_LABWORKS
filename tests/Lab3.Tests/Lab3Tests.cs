using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Directors;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;
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
        var director = new CombatAnalystDirector();

        ICreature creature = director.Direct(builder)
            .WithModifier(new MagicShieldModifierFactory())
            .WithModifier(new MagicShieldModifierFactory())
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
        var board = new PlayerBoard();
        var builder = new CombatAnalystBuilder();
        var director = new CombatAnalystDirector();

        ICreature creature = director.Direct(builder)
            .WithModifier(new MagicShieldModifierFactory())
            .WithModifier(new MagicShieldModifierFactory())
            .Build();

        // act
        board.AddCreature(creature);

        // assert
        Assert.NotSame(creature, board.GetCreatures()[0]);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_WhenFight_NotChangeOriginalBoardCreatures()
    {
        // arrange
        var board1 = new PlayerBoard();
        var board2 = new PlayerBoard();

        var builder1 = new MimicChestBuilder();
        var director1 = new MimicChestDirector();
        ICreature creature1 = director1.Direct(builder1).Build();

        var builder2 = new CombatAnalystBuilder();
        var director2 = new CombatAnalystDirector();
        ICreature creature2 = director2.Direct(builder2).Build();

        int originalAttack1 = creature1.CreatureAttack.Value;
        int originalHealth1 = creature1.CreatureHealth.Value;
        int originalAttack2 = creature2.CreatureAttack.Value;
        int originalHealth2 = creature2.CreatureHealth.Value;

        board1.AddCreature(creature1);
        board2.AddCreature(creature2);

        // act
        var fight = new Fight(board1, board2);
        fight.StartFight();

        // assert
        Assert.Equal(originalAttack1, board1.GetCreatures()[0].CreatureAttack.Value);
        Assert.Equal(originalHealth1, board1.GetCreatures()[0].CreatureHealth.Value);

        Assert.Equal(originalAttack2, board2.GetCreatures()[0].CreatureAttack.Value);
        Assert.Equal(originalHealth2, board2.GetCreatures()[0].CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_Changes_On_FirstPlayerBoard_NotChangeCreatures_On_SecondPlayerBoard()
    {
        // arrange
        var board1 = new PlayerBoard();
        var board2 = new PlayerBoard();

        var builder1 = new AmuletMasterBuilder();
        var director1 = new AmuletMasterDirector();
        ICreature creature1 = director1.Direct(builder1).Build();

        var builder2 = new AmuletMasterBuilder();
        var director2 = new AmuletMasterDirector();
        ICreature creature2 = director2.Direct(builder2).Build();

        board1.AddCreature(creature1);
        board2.AddCreature(creature2);

        // act
        board1.GetCreatures()[0].ChangeAttack(new Attack(10));

        // assert
        Assert.Equal(5, board2.GetCreatures()[0].CreatureAttack.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_Creature_With_AttackMasteryModifier_AttackTwice()
    {
        // arrange
        var builder1 = new MimicChestBuilder();
        var director1 = new MimicChestDirector();

        ICreature creature1 = director1.Direct(builder1)
            .WithModifier(new AttackMasteryModifierFactory())
            .Build();

        var builder2 = new EvilFighterBuilder();
        var director2 = new EvilFighterDirector();

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
        var director1 = new MimicChestDirector();

        ICreature creature1 = director1.Direct(builder1)
            .Build();

        var builder2 = new ImmortalHorrorBuilder();
        var director2 = new ImmortalHorrorDirector();

        ICreature creature2 = director2.Direct(builder2)
            .Build();

        // act
        creature1.AttackCreature(creature2);

        // assert
        Assert.Equal(1, creature2.CreatureHealth.Value);

        // act
        creature1.AttackCreature(creature2);

        // assert
        Assert.Equal(-3, creature2.CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_AmuletMaster_With_Spells_Beats_CombatAnalyst()
    {
        // arrange
        var board1 = new PlayerBoard();
        var board2 = new PlayerBoard();

        var builder1 = new AmuletMasterBuilder();
        var director1 = new AmuletMasterDirector();
        ICreature creature1 = director1.Direct(builder1).Build();

        var builder2 = new CombatAnalystBuilder();
        var director2 = new CombatAnalystDirector();
        ICreature creature2 = director2.Direct(builder2).Build();

        board1.AddCreature(creature1);
        board2.AddCreature(creature2);

        board1.ApplySpell(new PowerPotion(), creature1);
        board1.ApplySpell(new PowerPotion(), creature1);
        board1.ApplySpell(new EndurancePotion(), creature1);
        board1.ApplySpell(new EndurancePotion(), creature1);

        // act
        var fight = new Fight(board1, board2);
        FightResult fightResult = fight.StartFight();

        // assert
        Assert.Equal(new FightResult.Success(FightOutcome.FirstWin), fightResult);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_EndurancePotion_IncreaseHealth()
    {
        // arrange
        var board1 = new PlayerBoard();

        var builder1 = new AmuletMasterBuilder();
        var director1 = new AmuletMasterDirector();
        ICreature creature1 = director1.Direct(builder1).Build();

        // act
        board1.AddCreature(creature1);
        board1.ApplySpell(new EndurancePotion(), creature1);

        // assert
        Assert.Equal(7, creature1.CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_PowerPotion_IncreaseAttack()
    {
        // arrange
        var board1 = new PlayerBoard();

        var builder1 = new AmuletMasterBuilder();
        var director1 = new AmuletMasterDirector();
        ICreature creature1 = director1.Direct(builder1).Build();

        // act
        board1.AddCreature(creature1);
        board1.ApplySpell(new PowerPotion(), creature1);

        // assert
        Assert.Equal(10, creature1.CreatureAttack.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_ProtectionAmulet_Applies_MagicShield_ToCreature()
    {
        // arrange
        var board = new PlayerBoard();

        var builder = new MimicChestBuilder();
        var director = new MimicChestDirector();
        ICreature creature = director.Direct(builder).Build();

        board.AddCreature(creature);
        creature = board.ApplySpell(new ProtectionAmulet(), creature);

        // act
        creature.TakeDamage(new Attack(10000000));

        // assert
        Assert.Equal(1, creature.CreatureHealth.Value);

        // act
        creature.TakeDamage(new Attack(3));

        // assert
        Assert.Equal(-2, creature.CreatureHealth.Value);
    }

    [Fact]
    public void Run_ShouldReturnSuccess_When_MagicMirror_Swap_HealthAndAttack()
    {
        // arrange
        var board = new PlayerBoard();

        var builder = new MimicChestBuilder();
        var director = new MimicChestDirector();
        ICreature creature = director.Direct(builder).Build();

        int oldAttack = creature.CreatureAttack.Value;
        int oldHealth = creature.CreatureHealth.Value;

        board.AddCreature(creature);

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
        var board = new PlayerBoard();

        var creature1 = new MimicChest(new Attack(1), new Health(1));
        var creature2 = new MimicChest(new Attack(1), new Health(1));
        var creature3 = new MimicChest(new Attack(1), new Health(1));
        var creature4 = new MimicChest(new Attack(1), new Health(1));
        var creature5 = new MimicChest(new Attack(1), new Health(1));
        var creature6 = new MimicChest(new Attack(1), new Health(1));
        var creature7 = new MimicChest(new Attack(1), new Health(1));
        var creature8 = new MimicChest(new Attack(1), new Health(1));

        board.AddCreature(creature1);
        board.AddCreature(creature2);
        board.AddCreature(creature3);
        board.AddCreature(creature4);
        board.AddCreature(creature5);
        board.AddCreature(creature6);
        board.AddCreature(creature7);

        // act
        board.AddCreature(creature8);

        // assert
        Assert.Equal(7, board.GetCreatures().Count);
    }
}