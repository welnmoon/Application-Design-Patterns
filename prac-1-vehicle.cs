using System;
using System.Collections.Generic;

public class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public void StartEngine()
    {
        Console.WriteLine($"{Make} {Model} engine started.");
    }

    public void StopEngine()
    {
        Console.WriteLine($"{Make} {Model} engine stopped.");
    }
}

public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }
    public string TransmissionType { get; set; }

    public Car(string make, string model, int year, int numberOfDoors, string transmissionType)
        : base(make, model, year)
    {
        NumberOfDoors = numberOfDoors;
        TransmissionType = transmissionType;
    }
}

public class Motorcycle : Vehicle
{
    public string BodyType { get; set; }
    public bool HasStorageBox { get; set; }

    public Motorcycle(string make, string model, int year, string bodyType, bool hasStorageBox)
        : base(make, model, year)
    {
        BodyType = bodyType;
        HasStorageBox = hasStorageBox;
    }
}

public class Garage
{
    public List<Vehicle> Vehicles { get; private set; }

    public Garage()
    {
        Vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        Vehicles.Remove(vehicle);
    }
}

public class Fleet
{
    public List<Garage> Garages { get; private set; }

    public Fleet()
    {
        Garages = new List<Garage>();
    }

    public void AddGarage(Garage garage)
    {
        Garages.Add(garage);
    }

    public void RemoveGarage(Garage garage)
    {
        Garages.Remove(garage);
    }

    public Vehicle FindVehicle(string make, string model)
    {
        foreach (var garage in Garages)
        {
            foreach (var vehicle in garage.Vehicles)
            {
                if (vehicle.Make == make && vehicle.Model == model)
                {
                    return vehicle;
                }
            }
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var car1 = new Car("Toyota", "Camry", 2020, 4, "Automatic");
        var motorcycle1 = new Motorcycle("Yamaha", "R1", 2019, "Sport", true);

        var garage1 = new Garage();
        garage1.AddVehicle(car1);
        garage1.AddVehicle(motorcycle1);

        var fleet = new Fleet();
        fleet.AddGarage(garage1);

        var foundVehicle = fleet.FindVehicle("Toyota", "Camry");
        if (foundVehicle != null)
        {
            Console.WriteLine($"Found vehicle: {foundVehicle.Make} {foundVehicle.Model}");
        }

        fleet.RemoveGarage(garage1);
    }
}
