using System;
using System.Linq;

public static class Logger
{
    public static void Log(string level, string message)
    {
        Console.WriteLine($"{level.ToUpper()}: {message}");
    }
}

public class DatabaseService
{
    public void Connect()
    {
        string connectionString = Configuration.ConnectionString;
        Console.WriteLine("Подключение к базе данных с использованием строки подключения: " + connectionString);
    }
}

public static class Configuration
{
    public static string ConnectionString { get; } = "Server=myServer;Database=myDb;User Id=myUser;Password=myPass;";
}

public static class NumberProcessor
{
    public static void ProcessPositiveNumbers(int[] numbers)
    {
        if (numbers != null && numbers.Length > 0)
        {
            foreach (var number in numbers)
            {
                if (number > 0)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}

public static class MathUtils
{
    public static int Divide(int a, int b)
    {
        return b != 0 ? a / b : 0;
    }
}

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public void SaveToDatabase()
    {
        Console.WriteLine($"Сохранение пользователя {Name} в базу данных...");
    }

    public void SendEmail()
    {
        Console.WriteLine($"Отправка письма на {Email}...");
    }

    public void PrintAddressLabel()
    {
        Console.WriteLine($"Печать адресного ярлыка: {Address}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger.Log("error", "Ошибка подключения");
        Logger.Log("warning", "Предупреждение: Превышен лимит запросов");
        Logger.Log("info", "Приложение запущено");

        DatabaseService dbService = new DatabaseService();
        dbService.Connect();

        int[] numbers = { 1, -2, 3, 0, 4, 5 };
        NumberProcessor.ProcessPositiveNumbers(numbers);

        User user = new User { Name = "Нурс", Email = "nurs@mail.kz", Address = "ул. Ali, 1" };
        user.SaveToDatabase();
        user.SendEmail();
        user.PrintAddressLabel();

        int result = MathUtils.Divide(10, 0);
        Console.WriteLine($"Результат деления: {result}");
    }
}
