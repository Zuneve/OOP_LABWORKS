using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Copy;

public class CopyDestinationPathHandler : BaseHandler
{
    private FileCopyCommandArgumentsBuilder _fileCopyCommandArgumentsBuilder;

    public CopyDestinationPathHandler(FileCopyCommandArgumentsBuilder fileCopyCommandArgumentsBuilder)
    {
        _fileCopyCommandArgumentsBuilder = fileCopyCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _fileCopyCommandArgumentsBuilder = _fileCopyCommandArgumentsBuilder.WithDestinationPath(iterator.Current);

        return new HandleResult.Success(_fileCopyCommandArgumentsBuilder);
    }
}