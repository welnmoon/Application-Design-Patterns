using System;

public class OrderService
{
    private double CalculateTotalPrice(int quantity, double price)
    {
        return quantity * price;
    }

    public void CreateOrder(string productName, int quantity, double price)
    {
        double totalPrice = CalculateTotalPrice(quantity, price);
        Console.WriteLine($"Order for {productName} created. Total: {totalPrice}");
    }

    public void UpdateOrder(string productName, int quantity, double price)
    {
        double totalPrice = CalculateTotalPrice(quantity, price);
        Console.WriteLine($"Order for {productName} updated. New total: {totalPrice}");
    }
}

public class Vehicle
{
    public string Type { get; set; }

    public Vehicle(string type)
    {
        Type = type;
    }

    public void Start()
    {
        Console.WriteLine($"{Type} is starting");
    }

    public void Stop()
    {
        Console.WriteLine($"{Type} is stopping");
    }
}

public class Car : Vehicle
{
    public Car() : base("Car") { }
}

public class Truck : Vehicle
{
    public Truck() : base("Truck") { }
}

public class Client
{
    public static void Main(string[] args)
    {
        OrderService orderService = new OrderService();
        orderService.CreateOrder("Laptop", 2, 500.00);
        orderService.UpdateOrder("Laptop", 3, 500.00);

        Car car = new Car();
        car.Start();
        car.Stop();

        Truck truck = new Truck();
        truck.Start();
        truck.Stop();
    }
}
