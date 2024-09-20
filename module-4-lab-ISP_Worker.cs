using System;

public interface IWorker
{
    void Work();
}

public interface IEater
{
    void Eat();
}

public interface ISleeper
{
    void Sleep();
}

public class HumanWorker : IWorker, IEater, ISleeper
{
    public void Work()
    {
        Console.WriteLine("Human is working.");
    }

    public void Eat()
    {
        Console.WriteLine("Human is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine("Human is sleeping.");
    }
}

public class RobotWorker : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot is working.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IWorker human = new HumanWorker();
        IWorker robot = new RobotWorker();

        human.Work();
        ((IEater)human).Eat();
        ((ISleeper)human).Sleep();

        robot.Work();
    }
}
