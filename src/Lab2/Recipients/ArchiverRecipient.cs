using Itmo.ObjectOrientedProgramming.Lab2.Archivers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class ArchiverRecipient : IRecipient
{
    private readonly IArchiver _archiver;

    public ArchiverRecipient(IArchiver archiver)
    {
        _archiver = archiver;
    }

    public void Receive(Message message)
    {
        _archiver.Save(message);
    }
}