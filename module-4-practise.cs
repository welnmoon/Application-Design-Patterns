using System;
using System.Collections.Generic;

public interface IPayment
{
    void ProcessPayment(double amount);
}

public class CreditCardPayment : IPayment
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount}");
    }
}

public class PayPalPayment : IPayment
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount}");
    }
}

public interface IDelivery
{
    void DeliverOrder(Order order);
}

public class CourierDelivery : IDelivery
{
    public void DeliverOrder(Order order)
    {
        Console.WriteLine("Courier delivery initiated");
    }
}

public class PostDelivery : IDelivery
{
    public void DeliverOrder(Order order)
    {
        Console.WriteLine("Post delivery initiated");
    }
}

public interface INotification
{
    void SendNotification(string message);
}

public class EmailNotification : INotification
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

public class SmsNotification : INotification
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}

public class Order
{
    public List<Product> Products { get; set; } = new List<Product>();
    public double TotalAmount { get; set; }
    public IPayment PaymentMethod { get; set; }
    public IDelivery DeliveryMethod { get; set; }

    public void AddProduct(Product product)
    {
        Products.Add(product);
        TotalAmount += product.Price;
    }

    public void ProcessOrder()
    {
        Console.WriteLine($"Total amount: {TotalAmount}");
        PaymentMethod.ProcessPayment(TotalAmount);
        DeliveryMethod.DeliverOrder(this);
    }
}

public class Program
{
    public static void Main()
    {
        Order order = new Order();

        order.AddProduct(new Product { Name = "Laptop", Price = 1000 });
        order.AddProduct(new Product { Name = "Mouse", Price = 50 });

        order.PaymentMethod = new CreditCardPayment();

        order.DeliveryMethod = new CourierDelivery();

        order.ProcessOrder();

        INotification notification = new EmailNotification();
        notification.SendNotification("Your order has been processed!");
    }
}
