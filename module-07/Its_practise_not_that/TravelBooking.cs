using System;

namespace TravelBookingSystem
{
    // Интерфейс стратегии расчета стоимости поездки
    public interface ICostCalculationStrategy
    {
        decimal CalculateCost(decimal distance, int passengers, string serviceClass, bool hasDiscount);
    }

    // Стратегия расчета для самолета
    public class AirplaneCostCalculationStrategy : ICostCalculationStrategy
    {
        public decimal CalculateCost(decimal distance, int passengers, string serviceClass, bool hasDiscount)
        {
            decimal baseCost = distance * 0.5m * passengers;

            if (serviceClass == "business")
                baseCost *= 2;

            if (hasDiscount)
                baseCost *= 0.9m;

            return baseCost;
        }
    }

    // Стратегия расчета для поезда
    public class TrainCostCalculationStrategy : ICostCalculationStrategy
    {
        public decimal CalculateCost(decimal distance, int passengers, string serviceClass, bool hasDiscount)
        {
            decimal baseCost = distance * 0.2m * passengers;

            if (serviceClass == "business")
                baseCost *= 1.5m;

            if (hasDiscount)
                baseCost *= 0.85m;

            return baseCost;
        }
    }

    // Стратегия расчета для автобуса
    public class BusCostCalculationStrategy : ICostCalculationStrategy
    {
        public decimal CalculateCost(decimal distance, int passengers, string serviceClass, bool hasDiscount)
        {
            decimal baseCost = distance * 0.1m * passengers;

            if (serviceClass == "business")
                baseCost *= 1.2m;

            if (hasDiscount)
                baseCost *= 0.8m;

            return baseCost;
        }
    }

    // Контекст, который использует стратегии расчета стоимости
    public class TravelBookingContext
    {
        private ICostCalculationStrategy _costCalculationStrategy;

        public void SetCostCalculationStrategy(ICostCalculationStrategy strategy)
        {
            _costCalculationStrategy = strategy;
        }

        public decimal CalculateCost(decimal distance, int passengers, string serviceClass, bool hasDiscount)
        {
            if (_costCalculationStrategy == null)
            {
                throw new InvalidOperationException("Стратегия расчета стоимости не установлена.");
            }

            return _costCalculationStrategy.CalculateCost(distance, passengers, serviceClass, hasDiscount);
        }
    }

    // Клиентский код
    class Program
    {
        static void Main(string[] args)
        {
            TravelBookingContext bookingContext = new TravelBookingContext();

            Console.WriteLine("Выберите тип транспорта: 1 - Самолет, 2 - Поезд, 3 - Автобус");
            string transportChoice = Console.ReadLine();

            switch (transportChoice)
            {
                case "1":
                    bookingContext.SetCostCalculationStrategy(new AirplaneCostCalculationStrategy());
                    break;
                case "2":
                    bookingContext.SetCostCalculationStrategy(new TrainCostCalculationStrategy());
                    break;
                case "3":
                    bookingContext.SetCostCalculationStrategy(new BusCostCalculationStrategy());
                    break;
                default:
                    Console.WriteLine("Неверный выбор транспорта.");
                    return;
            }

            Console.WriteLine("Введите расстояние (км):");
            if (!decimal.TryParse(Console.ReadLine(), out decimal distance) || distance <= 0)
            {
                Console.WriteLine("Неверное значение расстояния.");
                return;
            }

            Console.WriteLine("Введите количество пассажиров:");
            if (!int.TryParse(Console.ReadLine(), out int passengers) || passengers <= 0)
            {
                Console.WriteLine("Неверное количество пассажиров.");
                return;
            }

            Console.WriteLine("Выберите класс обслуживания: эконом или бизнес");
            string serviceClass = Console.ReadLine().ToLower();
            if (serviceClass != "эконом" && serviceClass != "бизнес")
            {
                Console.WriteLine("Неверный класс обслуживания.");
                return;
            }

            Console.WriteLine("Есть ли скидка? (да/нет)");
            bool hasDiscount = Console.ReadLine().ToLower() == "да";

            try
            {
                decimal cost = bookingContext.CalculateCost(distance, passengers, serviceClass, hasDiscount);
                Console.WriteLine($"Стоимость поездки: {cost:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
