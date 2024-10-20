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

public class AirConditioner
{
    public void On()
    {
        Console.WriteLine("Air Conditioner is On");
    }

    public void Off()
    {
        Console.WriteLine("Air Conditioner is Off");
    }

    public void SetTemperature(int temperature)
    {
        Console.WriteLine($"Air Conditioner temperature set to {temperature}°C");
    }
}

public class Television
{
    public void On()
    {
        Console.WriteLine("Television is On");
    }

    public void Off()
    {
        Console.WriteLine("Television is Off");
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

public class AirConditionerOnCommand : ICommand
{
    private AirConditioner _airConditioner;

    public AirConditionerOnCommand(AirConditioner airConditioner)
    {
        _airConditioner = airConditioner;
    }

    public void Execute()
    {
        _airConditioner.On();
    }

    public void Undo()
    {
        _airConditioner.Off();
    }
}

public class AirConditionerOffCommand : ICommand
{
    private AirConditioner _airConditioner;

    public AirConditionerOffCommand(AirConditioner airConditioner)
    {
        _airConditioner = airConditioner;
    }

    public void Execute()
    {
        _airConditioner.Off();
    }

    public void Undo()
    {
        _airConditioner.On();
    }
}

public class TVOnCommand : ICommand
{
    private Television _television;

    public TVOnCommand(Television television)
    {
        _television = television;
    }

    public void Execute()
    {
        _television.On();
    }

    public void Undo()
    {
        _television.Off();
    }
}

public class TVOffCommand : ICommand
{
    private Television _television;

    public TVOffCommand(Television television)
    {
        _television = television;
    }

    public void Execute()
    {
        _television.Off();
    }

    public void Undo()
    {
        _television.On();
    }
}

public class RemoteControl
{
    private ICommand[] _onCommands;
    private ICommand[] _offCommands;
    private Stack<ICommand> _commandHistory = new Stack<ICommand>();

    public RemoteControl()
    {
        _onCommands = new ICommand[5];
        _offCommands = new ICommand[5];
    }

    public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
    {
        _onCommands[slot] = onCommand;
        _offCommands[slot] = offCommand;
    }

    public void OnButtonWasPressed(int slot)
    {
        if (_onCommands[slot] != null)
        {
            _onCommands[slot].Execute();
            _commandHistory.Push(_onCommands[slot]);
        }
        else
        {
            Console.WriteLine("No command assigned to this slot.");
        }
    }

    public void OffButtonWasPressed(int slot)
    {
        if (_offCommands[slot] != null)
        {
            _offCommands[slot].Execute();
            _commandHistory.Push(_offCommands[slot]);
        }
        else
        {
            Console.WriteLine("No command assigned to this slot.");
        }
    }

    public void UndoButtonWasPressed()
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

public class MacroCommand : ICommand
{
    private ICommand[] _commands;

    public MacroCommand(ICommand[] commands)
    {
        _commands = commands;
    }

    public void Execute()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }

    public void Undo()
    {
        for (int i = _commands.Length - 1; i >= 0; i--)
        {
            _commands[i].Undo();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        RemoteControl remote = new RemoteControl();

        Light livingRoomLight = new Light();
        AirConditioner airConditioner = new AirConditioner();
        Television tv = new Television();

        LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
        LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

        AirConditionerOnCommand acOn = new AirConditionerOnCommand(airConditioner);
        AirConditionerOffCommand acOff = new AirConditionerOffCommand(airConditioner);

        TVOnCommand tvOn = new TVOnCommand(tv);
        TVOffCommand tvOff = new TVOffCommand(tv);

        remote.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
        remote.SetCommand(1, acOn, acOff);
        remote.SetCommand(2, tvOn, tvOff);

        Console.WriteLine("Testing individual commands:");
        remote.OnButtonWasPressed(0);
        remote.OffButtonWasPressed(0);
        remote.OnButtonWasPressed(1);
        remote.OffButtonWasPressed(1);
        remote.OnButtonWasPressed(2);
        remote.OffButtonWasPressed(2);

        Console.WriteLine("\nTesting undo functionality:");
        remote.UndoButtonWasPressed();
        remote.UndoButtonWasPressed();

        Console.WriteLine("\nTesting macro command:");
        ICommand[] partyOn = { livingRoomLightOn, acOn, tvOn };
        ICommand[] partyOff = { livingRoomLightOff, acOff, tvOff };

        MacroCommand partyOnMacro = new MacroCommand(partyOn);
        MacroCommand partyOffMacro = new MacroCommand(partyOff);

        remote.SetCommand(3, partyOnMacro, partyOffMacro);

        remote.OnButtonWasPressed(3);
        remote.OffButtonWasPressed(3);
        remote.UndoButtonWasPressed();
    }
}
