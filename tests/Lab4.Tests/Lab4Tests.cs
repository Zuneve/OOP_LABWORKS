using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Lab4Tests
{
    private readonly CommandParser _parser = new();
    private readonly MainHandler _mainHandler = new(new ConsoleWriter(), new TreeViewSymbolsSettings());

    [Theory]
    [InlineData("connect smth -m local")]
    [InlineData("file show example.txt -m console")]
    [InlineData("file delete example.txt")]
    public void Handler_ShouldReturnSuccess_When_BasicCommand_Parsed(string input)
    {
        // arrange
        IEnumerator<string> iterator = _parser.ParseInput(input).GetEnumerator();
        iterator.MoveNext();

        // act
        HandleResult handleResult = _mainHandler.Handle(iterator);

        // assert
        HandleResult.Success success = Assert.IsType<HandleResult.Success>(handleResult);

        // act
        CommandArgumentsBuilderResult buildResult = success.Builder.Build();

        // assert
        CommandArgumentsBuilderResult.Success successBuild
            = Assert.IsType<CommandArgumentsBuilderResult.Success>(buildResult);

        Assert.NotNull(successBuild.Command);
        Assert.IsType<ICommand>(successBuild.Command, exactMatch: false);
    }

    [Theory]
    [InlineData("connect smth -m local", typeof(ConnectCommand))]
    [InlineData("file copy file1.txt user/file2.txt", typeof(CopyFileCommand))]
    [InlineData("file delete file.txt", typeof(DeleteFileCommand))]
    [InlineData("disconnect", typeof(DisconnectCommand))]
    [InlineData("file move user/mother/file1.txt user/father/", typeof(MoveFileCommand))]
    [InlineData("file rename file1.txt file1703.txt", typeof(RenameFileCommand))]
    [InlineData("file show file1.txt -m console", typeof(ShowFileCommand))]
    [InlineData("tree goto user/babushka", typeof(TreeGoToCommand))]
    [InlineData("tree list -d 1", typeof(TreeListCommand))]
    public void Run_ShouldReturnSuccess_When_Parser_Return_Correct_CommandType(string input, Type expectedType)
    {
        // arrange
        IEnumerator<string> iterator = _parser.ParseInput(input).GetEnumerator();
        iterator.MoveNext();

        // act
        HandleResult handleResult = _mainHandler.Handle(iterator);

        // assert
        HandleResult.Success success = Assert.IsType<HandleResult.Success>(handleResult);

        // act
        CommandArgumentsBuilderResult buildResult = success.Builder.Build();

        // assert
        CommandArgumentsBuilderResult.Success successBuild = Assert.IsType<CommandArgumentsBuilderResult.Success>(buildResult);

        Assert.IsType(expectedType, successBuild.Command);
    }

    [Theory]
    [InlineData("file change users/file.txt users/file.png")]
    public void Handler_ShouldReturn_Failed_When_UnknownCommand(string input)
    {
        // arrange
        IEnumerator<string> iterator = _parser.ParseInput(input).GetEnumerator();
        iterator.MoveNext();

        // act
        HandleResult handleResult = _mainHandler.Handle(iterator);

        // assert
        Assert.IsType<HandleResult.Failed>(handleResult);
    }
}