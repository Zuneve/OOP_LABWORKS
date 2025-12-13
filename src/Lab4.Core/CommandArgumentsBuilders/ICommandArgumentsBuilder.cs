using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders;

public interface ICommandArgumentsBuilder
{
    CommandArgumentsBuilderResult Build();
}