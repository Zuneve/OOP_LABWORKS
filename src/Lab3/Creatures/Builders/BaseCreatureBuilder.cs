using Itmo.ObjectOrientedProgramming.Lab3.Attributes;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public abstract class BaseCreatureBuilder : ICreatureBuilder
{
    private readonly List<IModifierApplierFactory> _modifierFactories = [];

    protected IEnumerable<IModifierApplierFactory> ModifierFactories => _modifierFactories;

    protected Attack? CreatureAttack { get; private set; }

    protected Health? CreatureHealth { get; private set; }

    public ICreatureBuilder WithAttack(Attack attack)
    {
        CreatureAttack = attack;
        return this;
    }

    public ICreatureBuilder WithHealth(Health health)
    {
        CreatureHealth = health;
        return this;
    }

    public ICreatureBuilder WithModifier(IModifierApplierFactory modifierApplierFactory)
    {
        _modifierFactories.Add(modifierApplierFactory);
        return this;
    }

    public abstract ICreature Build();
}