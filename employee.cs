using System;
using System.Collections.Generic;

public abstract class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Position { get; set; }

    public Employee(string name, int id, string position)
    {
        Name = name;
        Id = id;
        Position = position;
    }

    public abstract decimal CalculateSalary();

    public override string ToString()
    {
        return $"{Name} (ID: {Id}, Position: {Position}) - Salary: {CalculateSalary():C}";
    }
}

public class Worker : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public Worker(string name, int id, decimal hourlyRate, int hoursWorked)
        : base(name, id, "Worker")
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override decimal CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }
}

public class Manager : Employee
{
    public decimal FixedSalary { get; set; }
    public decimal Bonus { get; set; }

    public Manager(string name, int id, decimal fixedSalary, decimal bonus)
        : base(name, id, "Manager")
    {
        FixedSalary = fixedSalary;
        Bonus = bonus;
    }

    public override decimal CalculateSalary()
    {
        return FixedSalary + Bonus;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        employees.Add(new Worker("Nurs Nursov", 1, 20.0m, 160));
        employees.Add(new Worker("Ali Aliev", 2, 22.5m, 150));

        employees.Add(new Manager("Okko Okkov", 3, 3000.0m, 500.0m));
        employees.Add(new Manager("Indriver Indrive", 4, 3500.0m, 600.0m));

        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}


