using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;

public class FileShowCommandArgumentsBuilder : ICommandArgumentsBuilder
{
    private string? _path;

    private IWriter _writer = new ConsoleWriter();

    public FileShowCommandArgumentsBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public FileShowCommandArgumentsBuilder WithWriter(IWriter writer)
    {
        _writer = writer;
        return this;
    }

    public CommandArgumentsBuilderResult Build()
    {
        if (_path is null)
        {
            return new CommandArgumentsBuilderResult.Failed(new ArgumentNullError());
        }

        return new CommandArgumentsBuilderResult.Success(new ShowFileCommand(_path, _writer));
    }
}