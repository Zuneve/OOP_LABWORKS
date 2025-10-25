namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystem;

public class TextNotification : INotificationSystem
{
    public void Notify()
    {
        Console.WriteLine("Notification from TextNotification");
    }
}