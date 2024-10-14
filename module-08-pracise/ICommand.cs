using System;
using System.Collections.Generic;

namespace practise7
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light Turned On.");
        }
        public void TurnOff()
        {
            Console.WriteLine("Light Turned Off.");
        }
    }

    public class Television
    {
        public void TurnOn()
        {
            Console.WriteLine("Television Turned On.");
        }
        public void TurnOff()
        {
            Console.WriteLine("Television Turned Off.");
        }
    }

    // Light Commands
    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            this._light = light;
        }
        public void Execute()
        {
            _light.TurnOn();
        }
        public void Undo()
        {
            _light.TurnOff();
        }
    }

    public class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            this._light = light;
        }
        public void Execute()
        {
            _light.TurnOff();
        }
        public void Undo()
        {
            _light.TurnOn();
        }
    }

    // Television Commands
    public class TelevisionOnCommand : ICommand
    {
        private Television _tv;

        public TelevisionOnCommand(Television tv)
        {
            this._tv = tv;
        }
        public void Execute()
        {
            _tv.TurnOn();
        }
        public void Undo()
        {
            _tv.TurnOff();
        }
    }

    public class TelevisionOffCommand : ICommand
    {
        private Television _tv;

        public TelevisionOffCommand(Television tv)
        {
            this._tv = tv;
        }
        public void Execute()
        {
            _tv.TurnOff();
        }
        public void Undo()
        {
            _tv.TurnOn();
        }
    }

    public class RemoteControl
    {
        private ICommand _onCommand;
        private ICommand _offCommand;
        private readonly Stack<ICommand> _history = new Stack<ICommand>();

        public void SetCommands(ICommand onCommand, ICommand offCommand)
        {
            this._onCommand = onCommand;
            this._offCommand = offCommand;
        }

        public void PressOnButton()
        {
            _onCommand.Execute();
            _history.Push(_onCommand); // Запоминаем выполненную команду
        }

        public void PressOffButton()
        {
            _offCommand.Execute();
            _history.Push(_offCommand); // Запоминаем выполненную команду
        }

        public void PressUndoButton()
        {
            if (_history.Count > 0)
            {
                var command = _history.Pop();
                command.Undo();
            }
            else
            {
                Console.WriteLine("No commands to undo.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем устройства 
            Light livingRoomLight = new Light();
            Television tv = new Television();

            // Создаем команды для управления светом 
            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            // Создаем команды для управления телевизором 
            ICommand tvOn = new TelevisionOnCommand(tv);
            ICommand tvOff = new TelevisionOffCommand(tv);

            // Создаем пульт и привязываем команды к кнопкам 
            RemoteControl remote = new RemoteControl();

            // Управляем светом 
            remote.SetCommands(lightOn, lightOff);
            Console.WriteLine("Управление светом:");
            remote.PressOnButton();
            remote.PressOffButton();
            remote.PressUndoButton(); // Возврат к предыдущему состоянию

            // Управляем телевизором 
            remote.SetCommands(tvOn, tvOff);
            Console.WriteLine("\nУправление телевизором:");
            remote.PressOnButton();
            remote.PressOffButton();
            remote.PressUndoButton(); // Возврат к предыдущему состоянию
        }
    }
}
