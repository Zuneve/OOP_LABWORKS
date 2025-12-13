using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.ConnectCommandArgumentsBuilders;

public class ConnectCommandArgumentsBuilder : ICommandArgumentsBuilder
{
    private string? _path;

    private IFileSystem _fileSystem = new LocalFileSystem();

    public ConnectCommandArgumentsBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public ConnectCommandArgumentsBuilder WithFileSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }

    public CommandArgumentsBuilderResult Build()
    {
        if (_path is null)
        {
            return new CommandArgumentsBuilderResult.Failed(new ArgumentNullError());
        }

        return new CommandArgumentsBuilderResult.Success(new ConnectCommand(_path, _fileSystem));
    }
}