using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Copy;

public class CopySourcePathHandler : BaseHandler
{
    private FileCopyCommandArgumentsBuilder _fileCopyCommandArgumentsBuilder;

    public CopySourcePathHandler(FileCopyCommandArgumentsBuilder fileCopyCommandArgumentsBuilder)
    {
        _fileCopyCommandArgumentsBuilder = fileCopyCommandArgumentsBuilder;
    }

    public override HandleResult Handle(IEnumerator<string> iterator)
    {
        _fileCopyCommandArgumentsBuilder = _fileCopyCommandArgumentsBuilder.WithSourcePath(iterator.Current);

        if (!iterator.MoveNext())
        {
            return new HandleResult.Failed(new ArgumentNullError());
        }

        return Next is null
            ? new HandleResult.Failed(new ArgumentNullError())
            : Next.Handle(iterator);
    }
}