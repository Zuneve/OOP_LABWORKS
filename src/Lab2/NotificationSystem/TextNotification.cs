namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystem;

public class TextNotification : INotificationSystem
{
    private readonly string _notificationText;

    public TextNotification(string notificationText)
    {
        _notificationText = notificationText;
    }

    public void Notify()
    {
        Console.WriteLine($"Notification from TextNotification, {_notificationText}");
    }
}