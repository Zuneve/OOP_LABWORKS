using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.ConnectCommandArgumentsBuilders;

public class DisconnectCommandArgumentsBuilder : ICommandArgumentsBuilder
{
    public CommandArgumentsBuilderResult Build()
    {
        return new CommandArgumentsBuilderResult.Success(new DisconnectCommand());
    }
}