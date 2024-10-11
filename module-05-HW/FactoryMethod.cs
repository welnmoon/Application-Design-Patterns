using System;

public interface IVehicle
{
    void Drive();
    void Refuel();
}

public class Car : IVehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string FuelType { get; set; }

    public Car(string brand, string model, string fuelType)
    {
        Brand = brand;
        Model = model;
        FuelType = fuelType;
    }

    public void Drive()
    {
        Console.WriteLine($"Едем на {Brand} {Model}, который использует {FuelType}.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Заправляем {Brand} {Model} топливом типа {FuelType}.");
    }
}

public class Motorcycle : IVehicle
{
    public string Type { get; set; }
    public int EngineCapacity { get; set; }

    public Motorcycle(string type, int engineCapacity)
    {
        Type = type;
        EngineCapacity = engineCapacity;
    }

    public void Drive()
    {
        Console.WriteLine($"Едем на мотоцикле {Type} с объемом двигателя {EngineCapacity} куб. см.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Заправляем мотоцикл {Type}.");
    }
}

public class Truck : IVehicle
{
    public int LoadCapacity { get; set; }
    public int Axles { get; set; }

    public Truck(int loadCapacity, int axles)
    {
        LoadCapacity = loadCapacity;
        Axles = axles;
    }

    public void Drive()
    {
        Console.WriteLine($"Едем на грузовике с грузоподъемностью {LoadCapacity} тонн и {Axles} осями.");
    }

    public void Refuel()
    {
        Console.WriteLine($"Заправляем грузовик.");
    }
}

public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}

public class CarFactory : VehicleFactory
{
    private string _brand;
    private string _model;
    private string _fuelType;

    public CarFactory(string brand, string model, string fuelType)
    {
        _brand = brand;
        _model = model;
        _fuelType = fuelType;
    }

    public override IVehicle CreateVehicle()
    {
        return new Car(_brand, _model, _fuelType);
    }
}

public class MotorcycleFactory : VehicleFactory
{
    private string _type;
    private int _engineCapacity;

    public MotorcycleFactory(string type, int engineCapacity)
    {
        _type = type;
        _engineCapacity = engineCapacity;
    }

    public override IVehicle CreateVehicle()
    {
        return new Motorcycle(_type, _engineCapacity);
    }
}

public class TruckFactory : VehicleFactory
{
    private int _loadCapacity;
    private int _axles;

    public TruckFactory(int loadCapacity, int axles)
    {
        _loadCapacity = loadCapacity;
        _axles = axles;
    }

    public override IVehicle CreateVehicle()
    {
        return new Truck(_loadCapacity, _axles);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип транспорта: 1 - Автомобиль, 2 - Мотоцикл, 3 - Грузовик");
        int choice = int.Parse(Console.ReadLine());

        VehicleFactory factory = null;

        switch (choice)
        {
            case 1:
                Console.WriteLine("Введите марку автомобиля:");
                string carBrand = Console.ReadLine();
                Console.WriteLine("Введите модель автомобиля:");
                string carModel = Console.ReadLine();
                Console.WriteLine("Введите тип топлива:");
                string carFuelType = Console.ReadLine();
                factory = new CarFactory(carBrand, carModel, carFuelType);
                break;
            case 2:
                Console.WriteLine("Введите тип мотоцикла (спорт/турист):");
                string motoType = Console.ReadLine();
                Console.WriteLine("Введите объем двигателя:");
                int engineCapacity = int.Parse(Console.ReadLine());
                factory = new MotorcycleFactory(motoType, engineCapacity);
                break;
            case 3:
                Console.WriteLine("Введите грузоподъемность грузовика (в тоннах):");
                int loadCapacity = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите количество осей:");
                int axles = int.Parse(Console.ReadLine());
                factory = new TruckFactory(loadCapacity, axles);
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }

        if (factory != null)
        {
            IVehicle vehicle = factory.CreateVehicle();
            vehicle.Drive();
            vehicle.Refuel();
        }
    }
}
