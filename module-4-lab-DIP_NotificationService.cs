using System;

public interface INotificationSender
{
    void Send(string message);
}

public class EmailSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public class SmsSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class Notification
{
    private readonly INotificationSender _notificationSender;

    public Notification(INotificationSender notificationSender)
    {
        _notificationSender = notificationSender;
    }

    public void Send(string message)
    {
        _notificationSender.Send(message);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        INotificationSender emailSender = new EmailSender();
        INotificationSender smsSender = new SmsSender();

        Notification emailNotification = new Notification(emailSender);
        emailNotification.Send("Hello via Email");

        Notification smsNotification = new Notification(smsSender);
        smsNotification.Send("Hello via SMS");
    }
}
