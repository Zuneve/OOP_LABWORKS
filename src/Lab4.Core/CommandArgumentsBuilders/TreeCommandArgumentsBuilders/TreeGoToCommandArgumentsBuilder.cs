using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.TreeCommandArgumentsBuilders;

public class TreeGoToCommandArgumentsBuilder : ICommandArgumentsBuilder
{
    private string? _path;

    public TreeGoToCommandArgumentsBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public CommandArgumentsBuilderResult Build()
    {
        if (_path is null)
        {
            return new CommandArgumentsBuilderResult.Failed(new ArgumentNullError());
        }

        return new CommandArgumentsBuilderResult.Success(new TreeGoToCommand(_path));
    }
}