using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;

public class FileMoveCommandArgumentsBuilder : ICommandArgumentsBuilder
{
    private string? _sourcePath;

    private string? _destinationPath;

    public FileMoveCommandArgumentsBuilder WithSourcePath(string path)
    {
        _sourcePath = path;
        return this;
    }

    public FileMoveCommandArgumentsBuilder WithDestinationPath(string path)
    {
        _destinationPath = path;
        return this;
    }

    public CommandArgumentsBuilderResult Build()
    {
        if (_sourcePath is null || _destinationPath is null)
        {
            return new CommandArgumentsBuilderResult.Failed(new ArgumentNullError());
        }

        return new CommandArgumentsBuilderResult.Success(new MoveFileCommand(_sourcePath, _destinationPath));
    }
}