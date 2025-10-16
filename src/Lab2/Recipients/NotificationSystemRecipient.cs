using Itmo.ObjectOrientedProgramming.Lab2.NotificationSystem;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class NotificationSystemRecipient : IRecipient
{
    private readonly IReadOnlyList<string> _suspiciousWords;

    private readonly INotificationSystem _notificationSystem;

    public NotificationSystemRecipient(
        IReadOnlyList<string> suspiciousWords,
        INotificationSystem notificationSystem)
    {
        _suspiciousWords = suspiciousWords;
        _notificationSystem = notificationSystem;
    }

    public void Receive(Message message)
    {
        if (ContainsSuspiciousWord(message.Body.Value) ||
            ContainsSuspiciousWord(message.Tittle.Value))
        {
            _notificationSystem.Notify();
        }
    }

    private bool ContainsSuspiciousWord(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return false;
        }

        var suspiciousSet = new HashSet<string>(_suspiciousWords, StringComparer.InvariantCultureIgnoreCase);
        var currentStringBuilder = new System.Text.StringBuilder();

        foreach (char c in text)
        {
            if (char.IsLetterOrDigit(c))
            {
                currentStringBuilder.Append(c);
                continue;
            }

            if (currentStringBuilder.Length <= 0) continue;

            if (suspiciousSet.Contains(currentStringBuilder.ToString()))
            {
                return true;
            }

            currentStringBuilder.Clear();
        }

        return currentStringBuilder.Length > 0 && suspiciousSet.Contains(currentStringBuilder.ToString());
    }
}