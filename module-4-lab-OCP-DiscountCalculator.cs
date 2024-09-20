using System;

public abstract class DiscountCalculator
{
    public abstract double CalculateDiscount(double amount);
}

public class RegularDiscountCalculator : DiscountCalculator
{
    public override double CalculateDiscount(double amount)
    {
        return amount; 
    }
}

public class SilverDiscountCalculator : DiscountCalculator
{
    public override double CalculateDiscount(double amount)
    {
        return amount * 0.9;
    }
}

public class GoldDiscountCalculator : DiscountCalculator
{
    public override double CalculateDiscount(double amount)
    {
        return amount * 0.8;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        double amount = 1000;
        
        DiscountCalculator regularDiscount = new RegularDiscountCalculator();
        DiscountCalculator silverDiscount = new SilverDiscountCalculator();
        DiscountCalculator goldDiscount = new GoldDiscountCalculator();

        Console.WriteLine($"Regular customer: {regularDiscount.CalculateDiscount(amount)}");
        Console.WriteLine($"Silver customer: {silverDiscount.CalculateDiscount(amount)}");
        Console.WriteLine($"Gold customer: {goldDiscount.CalculateDiscount(amount)}");
    }
}
