using System;

public class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }
}

public interface ISalaryCalculator
{
    double CalculateSalary(Employee employee);
}

public class PermanentEmployeeSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 1.2;
    }
}

public class ContractEmployeeSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 1.1;
    }
}

public class InternEmployeeSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 0.8;
    }
}

public class FreelancerEmployeeSalaryCalculator : ISalaryCalculator
{
    public double CalculateSalary(Employee employee)
    {
        return employee.BaseSalary * 0.9;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Employee employee = new Employee { Name = "John Doe", BaseSalary = 1000 };

        ISalaryCalculator permanentCalculator = new PermanentEmployeeSalaryCalculator();
        ISalaryCalculator contractCalculator = new ContractEmployeeSalaryCalculator();
        ISalaryCalculator internCalculator = new InternEmployeeSalaryCalculator();
        ISalaryCalculator freelancerCalculator = new FreelancerEmployeeSalaryCalculator();

        Console.WriteLine("Зарплата постоянного сотрудника: " + permanentCalculator.CalculateSalary(employee));
        Console.WriteLine("Зарплата контрактного сотрудника: " + contractCalculator.CalculateSalary(employee));
        Console.WriteLine("Зарплата стажера: " + internCalculator.CalculateSalary(employee));
        Console.WriteLine("Зарплата фрилансера: " + freelancerCalculator.CalculateSalary(employee));
    }
}
