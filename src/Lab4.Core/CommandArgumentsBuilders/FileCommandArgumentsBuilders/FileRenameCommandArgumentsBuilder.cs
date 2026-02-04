using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;

public class FileRenameCommandArgumentsBuilder : ICommandArgumentsBuilder
{
    private string? _path;

    private string? _newFileName;

    public FileRenameCommandArgumentsBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public FileRenameCommandArgumentsBuilder WithNewFileName(string name)
    {
        _newFileName = name;
        return this;
    }

    public CommandArgumentsBuilderResult Build()
    {
        if (_path is null || _newFileName is null)
        {
            return new CommandArgumentsBuilderResult.Failed(new ArgumentNullError());
        }

        return new CommandArgumentsBuilderResult.Success(new RenameFileCommand(_path, _newFileName));
    }
}