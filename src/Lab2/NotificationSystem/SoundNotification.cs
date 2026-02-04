namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystem;

public class SoundNotification : INotificationSystem
{
    public SoundNotification() { }

    public void Notify()
    {
        Console.Beep();
    }
}