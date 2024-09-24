using System;

public interface ITransportProperty {
    string Version { get; set; }
    string Brand { get; set; }
}

abstract public class Transport : ITransportProperty {
    public string Version { get; set; }
    public string Brand { get; set; }

    public Transport(string version, string brand) {
        Version = version;
        Brand = brand;
    }

    public abstract void Move();
    public abstract void FuelUp();
}

public class Car : Transport {
    public Car(string version, string brand) : base(version, brand) { }

    public override void Move() {
        Console.WriteLine($"{Brand} {Version} едет, вруунн");
    }

    public override void FuelUp() {
        Console.WriteLine("Заправка машины бензином.");
    }
}

public class Motorcycle : Transport {
    public Motorcycle(string version, string brand) : base(version, brand) { }

    public override void Move() {
        Console.WriteLine($"{Brand} {Version} едет, бррр");
    }

    public override void FuelUp() {
        Console.WriteLine("Заправка мотоцикла бензином.");
    }
}

public class Plane : Transport {
    public Plane(string version, string brand) : base(version, brand) { }

    public override void Move() {
        Console.WriteLine($"{Brand} {Version} летит, вшшшш");
    }

    public override void FuelUp() {
        Console.WriteLine("Заправка самолета авиационным топливом.");
    }
}

public class Bike : Transport {
  public Bike(string version, string brand) : base(version, brand) { }
  
  public override void Move() {
        Console.WriteLine($"{Brand} {Version} едет, вшшшш");
    }
    public override void FuelUp() {
        Console.WriteLine("Заправка Велосипеда?)");
    }
}

abstract public class TransportFactory {
    public abstract Transport CreateTransport(string version, string brand);
}

public class CarFactory : TransportFactory {
    public override Transport CreateTransport(string version, string brand) {
        Console.WriteLine("CarFactory: Создание объекта типа Car.");
        return new Car(version, brand);
    }
}

public class MotorcycleFactory : TransportFactory {
    public override Transport CreateTransport(string version, string brand) {
        Console.WriteLine("MotorcycleFactory: Создание объекта типа Motorcycle.");
        return new Motorcycle(version, brand);
    }
}

public class PlaneFactory : TransportFactory {
    public override Transport CreateTransport(string version, string brand) {
        Console.WriteLine("PlaneFactory: Создание объекта типа Plane.");
        return new Plane(version, brand);
    }
}

public class BikeFactory : TransportFactory {
    public override Transport CreateTransport(string version, string brand) {
        Console.WriteLine("BikeFactory: Создание объекта типа Bike.");
        return new Bike(version, brand);
    }
}


public class HelloWorld
{
    public static void Main(string[] args)
    {
        TransportFactory carFactory = new CarFactory();
        TransportFactory motorcycleFactory = new MotorcycleFactory();
        TransportFactory planeFactory = new PlaneFactory();
        TransportFactory bikeFactory = new BikeFactory();

        Console.WriteLine("Выберите тип транспорта (1: Car, 2: Motorcycle, 3: Plane, 4: Bike): ");
        int choice = int.Parse(Console.ReadLine());

        Transport transport = null;

        switch (choice)
        {
            case 1:
                Console.WriteLine("Введите версию автомобиля:");
                string carVersion = Console.ReadLine();
                Console.WriteLine("Введите марку автомобиля:");
                string carBrand = Console.ReadLine();
                transport = carFactory.CreateTransport(carVersion, carBrand);
                break;
            case 2:
                Console.WriteLine("Введите версию мотоцикла:");
                string motorcycleVersion = Console.ReadLine();
                Console.WriteLine("Введите марку мотоцикла:");
                string motorcycleBrand = Console.ReadLine();
                transport = motorcycleFactory.CreateTransport(motorcycleVersion, motorcycleBrand);
                break;
            case 3:
                Console.WriteLine("Введите версию самолета:");
                string planeVersion = Console.ReadLine();
                Console.WriteLine("Введите марку самолета:");
                string planeBrand = Console.ReadLine();
                transport = planeFactory.CreateTransport(planeVersion, planeBrand);
                break;
            case 4:
                Console.WriteLine("Введите версию велосипеда:");
                string bikeVersion = Console.ReadLine();
                Console.WriteLine("Введите марку велосипеда:");
                string bikeBrand = Console.ReadLine();
                transport = bikeFactory.CreateTransport(bikeVersion, bikeBrand);
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        transport.Move();
        transport.FuelUp();
    }
}
