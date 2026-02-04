using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Rename;

public class RenamePathHandler : BaseHandler
{
    private FileRenameCommandArgumentsBuilder _fileRenameCommandArgumentsBuilder;

    public RenamePathHandler(FileRenameCommandArgumentsBuilder fileRenameCommandArgumentsBuilder)
    {
        _fileRenameCommandArgumentsBuilder = fileRenameCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _fileRenameCommandArgumentsBuilder = _fileRenameCommandArgumentsBuilder.WithPath(iterator.Current);

        if (!iterator.MoveNext())
        {
            return new HandleResult.Failed(new ArgumentNullError());
        }

        return Next is null
            ? new HandleResult.Failed(new ArgumentNullError())
            : Next.Handle(iterator);
    }
}