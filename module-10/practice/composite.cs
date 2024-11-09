using System;
using System.Collections.Generic;

public abstract class OrganizationComponent
{
    public string Name { get; set; }

    public OrganizationComponent(string name)
    {
        Name = name;
    }

    public abstract void Display(string indent = "");
    public abstract int GetBudget();
    public abstract int GetEmployeeCount();
}

public class Employee : OrganizationComponent
{
    public string Position { get; set; }
    public int Salary { get; set; }

    public Employee(string name, string position, int salary) : base(name)
    {
        Position = position;
        Salary = salary;
    }

    public override void Display(string indent = "")
    {
        Console.WriteLine($"{indent}- Employee: {Name}, Position: {Position}, Salary: {Salary}");
    }

    public override int GetBudget()
    {
        return Salary;
    }

    public override int GetEmployeeCount()
    {
        return 1;
    }
}

public class Department : OrganizationComponent
{
    private List<OrganizationComponent> _components = new List<OrganizationComponent>();

    public Department(string name) : base(name) { }

    public void Add(OrganizationComponent component)
    {
        _components.Add(component);
    }

    public void Remove(OrganizationComponent component)
    {
        _components.Remove(component);
    }

    public override void Display(string indent = "")
    {
        Console.WriteLine($"{indent}+ Department: {Name}");
        foreach (var component in _components)
        {
            component.Display(indent + "  ");
        }
    }

    public override int GetBudget()
    {
        int totalBudget = 0;
        foreach (var component in _components)
        {
            totalBudget += component.GetBudget();
        }
        return totalBudget;
    }

    public override int GetEmployeeCount()
    {
        int count = 0;
        foreach (var component in _components)
        {
            count += component.GetEmployeeCount();
        }
        return count;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Department rootDepartment = new Department("Head Office");
        Employee employee1 = new Employee("Alice", "Manager", 5000);
        Employee employee2 = new Employee("Bob", "Developer", 4000);
        Department subDepartment = new Department("IT Department");
        Employee employee3 = new Employee("Charlie", "Tester", 3000);

        rootDepartment.Add(employee1);
        rootDepartment.Add(subDepartment);
        subDepartment.Add(employee2);
        subDepartment.Add(employee3);

        rootDepartment.Display();
        Console.WriteLine($"Total Budget: {rootDepartment.GetBudget()}");
        Console.WriteLine($"Total Employees: {rootDepartment.GetEmployeeCount()}");
    }
}
