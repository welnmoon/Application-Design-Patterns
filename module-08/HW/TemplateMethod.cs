using System;

public abstract class Beverage
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (CustomerWantsCondiments())
        {
            AddCondiments();
        }
    }

    private void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    private void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }

    protected abstract void Brew();
    protected abstract void AddCondiments();

    protected virtual bool CustomerWantsCondiments()
    {
        while (true)
        {
            Console.WriteLine("Would you like condiments (yes/no)?");
            string input = Console.ReadLine().ToLower();
            if (input == "yes")
            {
                return true;
            }
            else if (input == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please answer 'yes' or 'no'.");
            }
        }
    }
}

public class Tea : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Steeping the tea");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon");
    }
}

public class Coffee : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Dripping coffee through filter");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk");
    }

    protected override bool CustomerWantsCondiments()
    {
        while (true)
        {
            Console.WriteLine("Would you like sugar and milk with your coffee (yes/no)?");
            string input = Console.ReadLine().ToLower();
            if (input == "yes")
            {
                return true;
            }
            else if (input == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please answer 'yes' or 'no'.");
            }
        }
    }
}

public class HotChocolate : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Mixing hot chocolate powder with water");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding whipped cream");
    }

    protected override bool CustomerWantsCondiments()
    {
        while (true)
        {
            Console.WriteLine("Would you like whipped cream with your hot chocolate (yes/no)?");
            string input = Console.ReadLine().ToLower();
            if (input == "yes")
            {
                return true;
            }
            else if (input == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please answer 'yes' or 'no'.");
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Beverage tea = new Tea();
        Console.WriteLine("\nMaking tea...");
        tea.PrepareRecipe();

        Beverage coffee = new Coffee();
        Console.WriteLine("\nMaking coffee...");
        coffee.PrepareRecipe();

        Beverage hotChocolate = new HotChocolate();
        Console.WriteLine("\nMaking hot chocolate...");
        hotChocolate.PrepareRecipe();
    }
}
