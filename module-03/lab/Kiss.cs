using System;

public class Calculator
{
    public void Add(int a, int b)
    {
        Console.WriteLine(a + b);
    }
}

public class Client
{
    public static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        calculator.Add(5, 10); 
    }
}
