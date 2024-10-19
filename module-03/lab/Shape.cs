using System;

public class Circle
{
    private double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }
}

public class Square
{
    private double _side;

    public Square(double side)
    {
        _side = side;
    }

    public double CalculateArea()
    {
        return _side * _side;
    }
}

public class Client
{
    public static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Console.WriteLine($"Circle Area: {circle.CalculateArea()}");

        Square square = new Square(4);
        Console.WriteLine($"Square Area: {square.CalculateArea()}");
    }
}
