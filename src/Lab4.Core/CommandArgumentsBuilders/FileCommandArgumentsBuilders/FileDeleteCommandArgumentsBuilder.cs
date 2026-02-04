using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;

public class FileDeleteCommandArgumentsBuilder : ICommandArgumentsBuilder
{
    private string? _path;

    public FileDeleteCommandArgumentsBuilder WithPath(string path)
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

        return new CommandArgumentsBuilderResult.Success(new DeleteFileCommand(_path));
    }
}