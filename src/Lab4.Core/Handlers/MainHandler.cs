using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.ConnectCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.FileCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandArgumentsBuilders.TreeCommandArgumentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.ConnectHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.ConnectHandlers.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Copy;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Delete;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Move;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Rename;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.FileHandlers.Show;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.TreeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.TreeHandlers.TreeGoTo;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers.CommandsHandlers.TreeHandlers.TreeList;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers;

public class MainHandler : BaseHandler
{
    public MainHandler(
        IWriter writer,
        TreeViewSymbolsSettings treeViewSymbolsSettings)
    {
        var connectCommandArgumentsBuilder = new ConnectCommandArgumentsBuilder();
        var fileCopyCommandArgumentsBuilder = new FileCopyCommandArgumentsBuilder();
        var fileDeleteCommandArgumentsBuilder = new FileDeleteCommandArgumentsBuilder();
        var fileMoveCommandArgumentsBuilder = new FileMoveCommandArgumentsBuilder();
        var fileRenameCommandArgumentsBuilder = new FileRenameCommandArgumentsBuilder();
        var fileShowCommandArgumentsBuilder = new FileShowCommandArgumentsBuilder();
        var treeGoToCommandArgumentsBuilder = new TreeGoToCommandArgumentsBuilder();
        TreeListCommandArgumentsBuilder treeListCommandArgumentsBuilder =
            new TreeListCommandArgumentsBuilder()
                .WithWriter(writer)
                .WithTreeViewSymbolSettings(treeViewSymbolsSettings);

        var connectHandler = new ConnectHandler();
        var disconnectHandler = new DisconnectHandler();
        var fileHandler = new FileHandler();
        var treeHandler = new TreeHandler();

        var connectPathHandler = new ConnectPathHandler(connectCommandArgumentsBuilder);
        var connectModeHandler = new ConnectModeHandler();
        var connectLocalSystemHandler = new ConnectLocalSystemHandler(connectCommandArgumentsBuilder);

        connectHandler.AddSubHandler(connectPathHandler);
        connectPathHandler.AddNext(connectModeHandler);
        connectModeHandler.AddSubHandler(connectLocalSystemHandler);

        var copyFileHandler = new CopyFileHandler();
        var copySourcePathHandler = new CopySourcePathHandler(fileCopyCommandArgumentsBuilder);
        var copyDestinationPathHandler = new CopyDestinationPathHandler(fileCopyCommandArgumentsBuilder);
        copyFileHandler.AddSubHandler(copySourcePathHandler);
        copySourcePathHandler.AddNext(copyDestinationPathHandler);

        var deleteFileHandler = new DeleteFileHandler();
        var deletePathHandler = new DeletePathHandler(fileDeleteCommandArgumentsBuilder);
        deleteFileHandler.AddSubHandler(deletePathHandler);

        var moveFileHandler = new MoveFileHandler();
        var moveSourcePathHandler = new MoveSourcePathHandler(fileMoveCommandArgumentsBuilder);
        var moveDestinationPathHandler = new MoveDestinationPathHandler(fileMoveCommandArgumentsBuilder);
        moveFileHandler.AddSubHandler(moveSourcePathHandler);
        moveSourcePathHandler.AddNext(moveDestinationPathHandler);

        var renameFileHandler = new RenameFileHandler();
        var renamePathHandler = new RenamePathHandler(fileRenameCommandArgumentsBuilder);
        var renameNewFileNameHandler = new RenameNewFileNameHandler(fileRenameCommandArgumentsBuilder);
        renameFileHandler.AddSubHandler(renamePathHandler);
        renamePathHandler.AddNext(renameNewFileNameHandler);

        var showFileHandler = new ShowFileHandler();
        var showPathHandler = new ShowPathHandler(fileShowCommandArgumentsBuilder);
        var showModeHandler = new ShowModeHandler();
        var showConsoleHandler = new ShowConsoleHandler(fileShowCommandArgumentsBuilder);
        showFileHandler.AddSubHandler(showPathHandler);
        showPathHandler.AddNext(showModeHandler);
        showModeHandler.AddSubHandler(showConsoleHandler);

        fileHandler.AddSubHandler(copyFileHandler);
        copyFileHandler.AddNext(deleteFileHandler);
        deleteFileHandler.AddNext(moveFileHandler);
        moveFileHandler.AddNext(renameFileHandler);
        renameFileHandler.AddNext(showFileHandler);

        var treeGoToHandler = new TreeGoToHandler();
        var treeGoToPathHandler = new TreeGoToPathHandler(treeGoToCommandArgumentsBuilder);
        treeGoToHandler.AddSubHandler(treeGoToPathHandler);

        var treeListHandler = new TreeListHandler();
        var treeListFlagHandler = new TreeListFlagHandler();
        var treeListDepthHandler = new TreeListDepthHandler(treeListCommandArgumentsBuilder);
        treeListHandler.AddSubHandler(treeListFlagHandler);
        treeListFlagHandler.AddSubHandler(treeListDepthHandler);

        treeHandler.AddSubHandler(treeGoToHandler);
        treeGoToHandler.AddNext(treeListHandler);

        connectHandler.AddNext(fileHandler);
        fileHandler.AddNext(treeHandler);
        treeHandler.AddNext(disconnectHandler);

        AddNext(connectHandler);
    }
}