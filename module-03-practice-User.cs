using System;
using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public User(string name, string email, string role)
    {
        Name = name;
        Email = email;
        Role = role;
    }
}

public class UserManager
{
    private List<User> users = new List<User>();

    public void AddUser(string name, string email, string role)
    {
        users.Add(new User(name, email, role));
        Console.WriteLine($"Пользователь {name} добавлен.");
    }

    public void RemoveUser(string email)
    {
        var user = users.Find(u => u.Email == email);
        if (user != null)
        {
            users.Remove(user);
            Console.WriteLine($"Пользователь {user.Name} удален.");
        }
        else
        {
            Console.WriteLine("Пользователь не найден.");
        }
    }

    public void UpdateUser(string email, string newName, string newRole)
    {
        var user = users.Find(u => u.Email == email);
        if (user != null)
        {
            user.Name = newName;
            user.Role = newRole;
            Console.WriteLine($"Пользователь {email} обновлен.");
        }
        else
        {
            Console.WriteLine("Пользователь не найден.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        UserManager userManager = new UserManager();
        
        userManager.AddUser("Иван", "ivan@example.com", "Admin");
        userManager.AddUser("Петр", "petr@example.com", "User");
        
        userManager.UpdateUser("ivan@example.com", "Иван Петров", "Super Admin");
        
        userManager.RemoveUser("petr@example.com");
    }
}
