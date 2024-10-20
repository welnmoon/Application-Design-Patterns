using System;
using System.Collections.Generic;

public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light
{
    public void On()
    {
        Console.WriteLine("Light is On");
    }

    public void Off()
    {
        Console.WriteLine("Light is Off");
    }
}

public class Door
{
    public void Open()
    {
        Console.WriteLine("Door is Open");
    }

    public void Close()
    {
        Console.WriteLine("Door is Closed");
    }
}

public class Thermostat
{
    private int _temperature;

    public Thermostat(int temperature)
    {
        _temperature = temperature;
    }

    public void IncreaseTemperature()
    {
        _temperature++;
        Console.WriteLine($"Temperature increased to {_temperature}");
    }

    public void DecreaseTemperature()
    {
        _temperature--;
        Console.WriteLine($"Temperature decreased to {_temperature}");
    }
}

public class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }

    public void Undo()
    {
        _light.Off();
    }
}

public class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }

    public void Undo()
    {
        _light.On();
    }
}

public class DoorOpenCommand : ICommand
{
    private Door _door;

    public DoorOpenCommand(Door door)
    {
        _door = door;
    }

    public void Execute()
    {
        _door.Open();
    }

    public void Undo()
    {
        _door.Close();
    }
}

public class DoorCloseCommand : ICommand
{
    private Door _door;

    public DoorCloseCommand(Door door)
    {
        _door = door;
    }

    public void Execute()
    {
        _door.Close();
    }

    public void Undo()
    {
        _door.Open();
    }
}

public class IncreaseTemperatureCommand : ICommand
{
    private Thermostat _thermostat;

    public IncreaseTemperatureCommand(Thermostat thermostat)
    {
        _thermostat = thermostat;
    }

    public void Execute()
    {
        _thermostat.IncreaseTemperature();
    }

    public void Undo()
    {
        _thermostat.DecreaseTemperature();
    }
}

public class DecreaseTemperatureCommand : ICommand
{
    private Thermostat _thermostat;

    public DecreaseTemperatureCommand(Thermostat thermostat)
    {
        _thermostat = thermostat;
    }

    public void Execute()
    {
        _thermostat.DecreaseTemperature();
    }

    public void Undo()
    {
        _thermostat.IncreaseTemperature();
    }
}

public class Invoker
{
    private Stack<ICommand> _commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void UndoCommand()
    {
        if (_commandHistory.Count > 0)
        {
            ICommand lastCommand = _commandHistory.Pop();
            lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("No commands to undo.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Invoker invoker = new Invoker();

        Light light = new Light();
        Door door = new Door();
        Thermostat thermostat = new Thermostat(22);

        ICommand lightOn = new LightOnCommand(light);
        ICommand lightOff = new LightOffCommand(light);
        ICommand doorOpen = new DoorOpenCommand(door);
        ICommand doorClose = new DoorCloseCommand(door);
        ICommand tempUp = new IncreaseTemperatureCommand(thermostat);
        ICommand tempDown = new DecreaseTemperatureCommand(thermostat);

        invoker.ExecuteCommand(lightOn);
        invoker.ExecuteCommand(lightOff);
        invoker.ExecuteCommand(doorOpen);
        invoker.ExecuteCommand(doorClose);
        invoker.ExecuteCommand(tempUp);
        invoker.ExecuteCommand(tempDown);

        Console.WriteLine("\nUndoing last command:");
        invoker.UndoCommand();
        Console.WriteLine("Undoing another command:");
        invoker.UndoCommand();

        Television tv = new Television();
        ICommand tvOn = new TVOnCommand(tv);
        ICommand tvOff = new TVOffCommand(tv);

        invoker.ExecuteCommand(tvOn);
        invoker.ExecuteCommand(tvOff);
    }
}

public class Television
{
    public void On()
    {
        Console.WriteLine("TV is On");
    }

    public void Off()
    {
        Console.WriteLine("TV is Off");
    }
}

public class TVOnCommand : ICommand
{
    private Television _tv;

    public TVOnCommand(Television tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.On();
    }

    public void Undo()
    {
        _tv.Off();
    }
}

public class TVOffCommand : ICommand
{
    private Television _tv;

    public TVOffCommand(Television tv)
    {
        _tv = tv;
    }

    public void Execute()
    {
        _tv.Off();
    }

    public void Undo()
    {
        _tv.On();
    }
}
