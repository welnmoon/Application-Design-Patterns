using System;
using System.Collections.Generic;

public interface IMediator
{
    void SendMessage(string message, User sender);
    void SendPrivateMessage(string message, User sender, User receiver);
    void AddUser(User user);
    void RemoveUser(User user);
}

public class ChatRoom : IMediator
{
    private List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
        NotifyUsers($"{user.Name} has joined the chat.");
    }

    public void RemoveUser(User user)
    {
        _users.Remove(user);
        NotifyUsers($"{user.Name} has left the chat.");
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
            {
                user.ReceiveMessage(message, sender);
            }
        }
    }

    public void SendPrivateMessage(string message, User sender, User receiver)
    {
        if (_users.Contains(receiver))
        {
            receiver.ReceiveMessage(message, sender);
        }
        else
        {
            Console.WriteLine($"{sender.Name} tried to send a private message to {receiver.Name}, but they are not in the chat.");
        }
    }

    private void NotifyUsers(string notification)
    {
        foreach (var user in _users)
        {
            user.ReceiveNotification(notification);
        }
    }
}

public abstract class User
{
    protected IMediator _mediator;
    public string Name { get; private set; }

    public User(IMediator mediator, string name)
    {
        _mediator = mediator;
        Name = name;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        _mediator.SendMessage(message, this);
    }

    public void SendPrivateMessage(string message, User receiver)
    {
        Console.WriteLine($"{Name} sends private message to {receiver.Name}: {message}");
        _mediator.SendPrivateMessage(message, this, receiver);
    }

    public abstract void ReceiveMessage(string message, User sender);
    public abstract void ReceiveNotification(string notification);
}

public class RegularUser : User
{
    public RegularUser(IMediator mediator, string name) : base(mediator, name) { }

    public override void ReceiveMessage(string message, User sender)
    {
        Console.WriteLine($"{Name} received a message from {sender.Name}: {message}");
    }

    public override void ReceiveNotification(string notification)
    {
        Console.WriteLine($"{Name} received notification: {notification}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IMediator chatRoom = new ChatRoom();

        User user1 = new RegularUser(chatRoom, "Alice");
        User user2 = new RegularUser(chatRoom, "Bob");
        User user3 = new RegularUser(chatRoom, "Charlie");

        chatRoom.AddUser(user1);
        chatRoom.AddUser(user2);
        chatRoom.AddUser(user3);

        user1.SendMessage("Hello everyone!");
        user2.SendPrivateMessage("How are you?", user1);
        user3.SendMessage("Hi, all!");

        chatRoom.RemoveUser(user2);

        user1.SendMessage("Goodbye!");
    }
}
