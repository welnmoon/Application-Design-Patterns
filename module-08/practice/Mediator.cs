using System;
using System.Collections.Generic;

public interface IMediator
{
    void SendMessage(string message, IUser sender, string channel);
    void AddUser(IUser user, string channel);
    void RemoveUser(IUser user, string channel);
}

public interface IUser
{
    string Name { get; }
    void SendMessage(string message, string channel);
    void ReceiveMessage(string message, IUser sender, string channel);
    void ReceiveNotification(string notification, string channel);
}

public class ChatMediator : IMediator
{
    private Dictionary<string, List<IUser>> _channels = new Dictionary<string, List<IUser>>();

    public void SendMessage(string message, IUser sender, string channel)
    {
        if (_channels.ContainsKey(channel))
        {
            foreach (var user in _channels[channel])
            {
                if (user != sender)
                {
                    user.ReceiveMessage(message, sender, channel);
                }
            }
        }
    }

    public void AddUser(IUser user, string channel)
    {
        if (!_channels.ContainsKey(channel))
        {
            _channels[channel] = new List<IUser>();
        }
        _channels[channel].Add(user);
        NotifyUsers($"{user.Name} has joined the channel {channel}.", user, channel);
    }

    public void RemoveUser(IUser user, string channel)
    {
        if (_channels.ContainsKey(channel))
        {
            _channels[channel].Remove(user);
            NotifyUsers($"{user.Name} has left the channel {channel}.", user, channel);
        }
    }

    private void NotifyUsers(string notification, IUser sender, string channel)
    {
        foreach (var user in _channels[channel])
        {
            if (user != sender)
            {
                user.ReceiveNotification(notification, channel);
            }
        }
    }
}

public class User : IUser
{
    private IMediator _mediator;
    public string Name { get; private set; }

    public User(IMediator mediator, string name)
    {
        _mediator = mediator;
        Name = name;
    }

    public void SendMessage(string message, string channel)
    {
        Console.WriteLine($"{Name} sends: {message} to channel {channel}");
        _mediator.SendMessage(message, this, channel);
    }

    public void ReceiveMessage(string message, IUser sender, string channel)
    {
        Console.WriteLine($"{Name} received a message from {sender.Name} in {channel}: {message}");
    }

    public void ReceiveNotification(string notification, string channel)
    {
        Console.WriteLine($"{Name} received notification in {channel}: {notification}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IMediator chatMediator = new ChatMediator();

        IUser user1 = new User(chatMediator, "Alice");
        IUser user2 = new User(chatMediator, "Bob");
        IUser user3 = new User(chatMediator, "Charlie");

        chatMediator.AddUser(user1, "General");
        chatMediator.AddUser(user2, "General");
        chatMediator.AddUser(user3, "General");

        user1.SendMessage("Hello everyone!", "General");
        user2.SendMessage("Hey Alice!", "General");

        chatMediator.RemoveUser(user2, "General");

        user3.SendMessage("Goodbye!", "General");

        chatMediator.AddUser(user2, "Sports");
        user2.SendMessage("Let's talk about sports!", "Sports");
    }
}
