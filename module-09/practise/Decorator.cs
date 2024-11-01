using System;

namespace CafeOrderSystem
{
    // Базовый интерфейс напитка
    public abstract class Beverage
    {
        public abstract string Description { get; }
        public abstract double Cost();
    }

    // Классы напитков
    public class Espresso : Beverage
    {
        public override string Description => "Espresso";
        public override double Cost() => 3.00;
    }

    public class Tea : Beverage
    {
        public override string Description => "Tea";
        public override double Cost() => 2.50;
    }

    public class Latte : Beverage
    {
        public override string Description => "Latte";
        public override double Cost() => 3.50;
    }

    public class Mocha : Beverage
    {
        public override string Description => "Mocha";
        public override double Cost() => 4.00;
    }

    // Абстрактный класс-декоратор для добавок
    public abstract class BeverageDecorator : Beverage
    {
        protected Beverage _beverage;
        public BeverageDecorator(Beverage beverage) => _beverage = beverage;
        public override string Description => _beverage.Description;
    }

    // Конкретные декораторы для добавок
    public class Milk : BeverageDecorator
    {
        public Milk(Beverage beverage) : base(beverage) { }
        public override string Description => _beverage.Description + ", Milk";
        public override double Cost() => _beverage.Cost() + 0.50;
    }

    public class Sugar : BeverageDecorator
    {
        public Sugar(Beverage beverage) : base(beverage) { }
        public override string Description => _beverage.Description + ", Sugar";
        public override double Cost() => _beverage.Cost() + 0.20;
    }

    public class WhippedCream : BeverageDecorator
    {
        public WhippedCream(Beverage beverage) : base(beverage) { }
        public override string Description => _beverage.Description + ", Whipped Cream";
        public override double Cost() => _beverage.Cost() + 0.70;
    }

    public class Syrup : BeverageDecorator
    {
        public Syrup(Beverage beverage) : base(beverage) { }
        public override string Description => _beverage.Description + ", Syrup";
        public override double Cost() => _beverage.Cost() + 0.60;
    }

    // Клиентский код
    class Program
    {
        static void Main()
        {
            // Базовый напиток с добавками
            Beverage beverage = new Espresso();
            beverage = new Milk(beverage);
            beverage = new Sugar(beverage);
            beverage = new WhippedCream(beverage);

            Console.WriteLine($"{beverage.Description} - Cost: ${beverage.Cost():0.00}");

            // Другой напиток с другими добавками
            Beverage beverage2 = new Latte();
            beverage2 = new Syrup(beverage2);
            beverage2 = new Milk(beverage2);

            Console.WriteLine($"{beverage2.Description} - Cost: ${beverage2.Cost():0.00}");
        }
    }
}
