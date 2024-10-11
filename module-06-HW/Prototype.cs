using System;
using System.Collections.Generic;

public class Product : ICloneable
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

public class Order : ICloneable
{
    public List<Product> Products { get; set; } = new List<Product>();
    public decimal DeliveryCost { get; set; }
    public decimal Discount { get; set; }
    public string PaymentMethod { get; set; }

    public object Clone()
    {
        var clonedOrder = (Order)this.MemberwiseClone();
        clonedOrder.Products = new List<Product>();
        foreach (var product in this.Products)
        {
            clonedOrder.Products.Add((Product)product.Clone());
        }
        return clonedOrder;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var order1 = new Order
        {
            DeliveryCost = 5.0m,
            Discount = 2.0m,
            PaymentMethod = "Credit Card"
        };
        order1.Products.Add(new Product { Name = "Laptop", Price = 1000.0m });

        var order2 = (Order)order1.Clone();
        order2.Products[0].Price = 950.0m;

        Console.WriteLine(order1.Products[0].Price); // 1000
        Console.WriteLine(order2.Products[0].Price); // 950
    }
}
