using System;

public interface INotificationSender
{
    void Send(string message);
}

public class EmailSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

public class SmsSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine("SMS sent: " + message);
    }
}

public class NotificationService
{
    private readonly INotificationSender _notificationSender;

    public NotificationService(INotificationSender notificationSender)
    {
        _notificationSender = notificationSender;
    }

    public void SendNotification(string message)
    {
        _notificationSender.Send(message);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        NotificationService emailNotificationService = new NotificationService(new EmailSender());
        emailNotificationService.SendNotification("This is an email message.");

        NotificationService smsNotificationService = new NotificationService(new SmsSender());
        smsNotificationService.SendNotification("This is an SMS message.");
    }
}
