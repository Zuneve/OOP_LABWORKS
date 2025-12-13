using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.ConnectHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.FileHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.TreeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers;

public class MainHandler : BaseHandler
{
    public MainHandler(
        IWriter writer,
        TreeViewSymbolsSettings treeViewSymbolsSettings)
    {
        var connectHandler = new ConnectHandler();
        var disconnectHandler = new DisconnectHandler();
        var copyFileHandler = new CopyFileHandler();
        var deleteFileHandler = new DeleteFileHandler();
        var moveFileHandler = new MoveFileHandler();
        var renameFileHandler = new RenameFileHandler();
        var showFileHandler = new ShowFileHandler();
        var treeGoToHandler = new TreeGoToHandler();
        var treeListHandler = new TreeListHandler(writer, treeViewSymbolsSettings);

        connectHandler
            .AddNext(disconnectHandler)
            .AddNext(copyFileHandler)
            .AddNext(deleteFileHandler)
            .AddNext(moveFileHandler)
            .AddNext(renameFileHandler)
            .AddNext(showFileHandler)
            .AddNext(treeGoToHandler)
            .AddNext(treeListHandler);

        AddNext(connectHandler);
    }
}