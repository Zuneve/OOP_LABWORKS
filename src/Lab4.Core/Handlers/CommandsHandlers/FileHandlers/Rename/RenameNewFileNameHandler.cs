using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Rename;

public class RenameNewFileNameHandler : BaseHandler
{
    private FileRenameCommandArgumentsBuilder _fileRenameCommandArgumentsBuilder;

    public RenameNewFileNameHandler(FileRenameCommandArgumentsBuilder fileRenameCommandArgumentsBuilder)
    {
        _fileRenameCommandArgumentsBuilder = fileRenameCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _fileRenameCommandArgumentsBuilder = _fileRenameCommandArgumentsBuilder.WithNewFileName(iterator.Current);

        return new HandleResult.Success(_fileRenameCommandArgumentsBuilder);
    }
}