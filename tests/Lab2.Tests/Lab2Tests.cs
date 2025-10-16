using Itmo.ObjectOrientedProgramming.Lab2.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Attributes;
using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Lab2Tests
{
    [Fact]
    public void Run_Should_ReturnSuccess_When_ReceivedMessage_HasStatus_UnreadMessage()
    {
        // arrange
        var user = new User();

        var message = new Message(
            new MessageTittle("Hello"),
            new MessageBody("Sasha"),
            new MessagePriorityScore(1));

        // act
        user.Receive(message);

        // assert
        Assert.Equal(new MessageReadStatus(false), message.MessageStatus);
    }

    [Fact]
    public void Run_Should_ReturnSuccess_When_UserChangeMessageStatusToRead()
    {
        // arrange
        var user = new User();

        var message = new Message(
            new MessageTittle("Hello"),
            new MessageBody("Sasha"),
            new MessagePriorityScore(1));

        // act
        user.Receive(message);

        user.MarkAsRead(message.Id);

        // assert
        Assert.Equal(new MessageReadStatus(true), message.MessageStatus);
    }

    [Fact]
    public void MarkAsRead_ThrowsInvalidOperation_When_MessageAlreadyRead()
    {
        // arrange
        var user = new User();

        var message = new Message(
            new MessageTittle("Hello"),
            new MessageBody("Sasha"),
            new MessagePriorityScore(1));

        // act
        user.Receive(message);

        user.MarkAsRead(message.Id);

        // assert
        Assert.Throws<InvalidOperationException>(() => user.MarkAsRead(message.Id));
    }

    [Fact]
    public void FilteredMessage_ShouldNotReachUser()
    {
        // arrange
        IRecipient userRecipient = Substitute.For<IRecipient>();
        var filteredRecipient = new FilteringRecipientDecorator(
            userRecipient,
            new MinAllowedImportance(3));

        var message = new Message(
            new MessageTittle("Hello"),
            new MessageBody("Sasha"),
            new MessagePriorityScore(1));

        // act
        filteredRecipient.Receive(message);

        // assert
        userRecipient.DidNotReceive().Receive(Arg.Any<Message>());
    }

    [Fact]
    public void MessageShouldBeLogged_When_UserSendMessage()
    {
        // arrange
        IRecipient userRecipient = Substitute.For<IRecipient>();
        ILogger logger = Substitute.For<ILogger>();
        var loggingRecipient = new LoggingRecipientDecorator(userRecipient, logger);

        var message = new Message(
            new MessageTittle("Hello"),
            new MessageBody("Sasha"),
            new MessagePriorityScore(3));

        // act
        loggingRecipient.Receive(message);

        // assert
        logger.Received(1).Log(Arg.Any<Message>());
    }

    [Fact]
    public void FormattingArchiver_Save_ShouldCallFormatter()
    {
        // arrange
        var message = new Message(
            new MessageTittle("Hello"),
            new MessageBody("Sasha"),
            new MessagePriorityScore(3));

        IFormatter formatter = Substitute.For<IFormatter>();
        var formattingArchiver = new FormattingArchiver(formatter);

        // act
        formattingArchiver.Save(message);

        // assert
        formatter.Received(1).Format(message);
    }

    [Fact]
    public void WhenTwoRecipients_WithDifferentFilteringLogic_OneOfThem_HaveHigherMessagePriority_OnlyOneMessageMustReachUser()
    {
        // arrange
        var user = new User();

        var recipientWithFilter = new FilteringRecipientDecorator(
            new UserRecipient(user),
            new MinAllowedImportance(3));

        var recipientWithoutFilter = new UserRecipient(user);

        var message = new Message(
            new MessageTittle("Hello"),
            new MessageBody("Sasha"),
            new MessagePriorityScore(2));

        // act
        recipientWithFilter.Receive(message);
        recipientWithoutFilter.Receive(message);

        // assert
        Assert.Equal(1, user.MessageCount);
        Assert.True(user.HasMessage(message.Id));
    }
}