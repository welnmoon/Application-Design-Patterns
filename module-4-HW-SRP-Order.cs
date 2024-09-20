using System;
using System.Collections.Generic;

public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

public class PriceCalculator
{
    public double CalculateTotalPrice(Order order)
    {
        return order.Quantity * order.Price * 0.9; 
    }
}

public class PaymentProcessor
{
    public void ProcessPayment(string paymentDetails)
    {
        Console.WriteLine("Payment processed using: " + paymentDetails);
    }
}

public class EmailNotification
{
    public void SendConfirmationEmail(string email)
    {
        Console.WriteLine("Confirmation email sent to: " + email);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Order order = new Order
        {
            ProductName = "Laptop",
            Quantity = 2,
            Price = 1500.00
        };

        PriceCalculator calculator = new PriceCalculator();
        double totalPrice = calculator.CalculateTotalPrice(order);
        Console.WriteLine("Total Price: " + totalPrice);

        PaymentProcessor paymentProcessor = new PaymentProcessor();
        paymentProcessor.ProcessPayment("Credit Card");

        EmailNotification notification = new EmailNotification();
        notification.SendConfirmationEmail("customer@example.com");
    }
}
