using System;
using System.Collections.Generic;

namespace DesignPatterns
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
            Console.WriteLine("Свет включен.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Свет выключен.");
        }
    }

    public class Television
    {
        public void TurnOn()
        {
            Console.WriteLine("Телевизор включен.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Телевизор выключен.");
        }
    }

    public class AirConditioner
    {
        public void TurnOn()
        {
            Console.WriteLine("Кондиционер включен.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Кондиционер выключен.");
        }
    }

    public class AudioSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Аудиосистема включена.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Аудиосистема выключена.");
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
            _light = light;
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

    public class TelevisionOnCommand : ICommand
    {
        private Television _tv;

        public TelevisionOnCommand(Television tv)
        {
            _tv = tv;
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
            _tv = tv;
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

    public class AirConditionerOnCommand : ICommand
    {
        private AirConditioner _ac;

        public AirConditionerOnCommand(AirConditioner ac)
        {
            _ac = ac;
        }

        public void Execute()
        {
            _ac.TurnOn();
        }

        public void Undo()
        {
            _ac.TurnOff();
        }
    }

    public class AirConditionerOffCommand : ICommand
    {
        private AirConditioner _ac;

        public AirConditionerOffCommand(AirConditioner ac)
        {
            _ac = ac;
        }

        public void Execute()
        {
            _ac.TurnOff();
        }

        public void Undo()
        {
            _ac.TurnOn();
        }
    }

    public class AudioSystemOnCommand : ICommand
    {
        private AudioSystem _audioSystem;

        public AudioSystemOnCommand(AudioSystem audioSystem)
        {
            _audioSystem = audioSystem;
        }

        public void Execute()
        {
            _audioSystem.TurnOn();
        }

        public void Undo()
        {
            _audioSystem.TurnOff();
        }
    }

    public class AudioSystemOffCommand : ICommand
    {
        private AudioSystem _audioSystem;

        public AudioSystemOffCommand(AudioSystem audioSystem)
        {
            _audioSystem = audioSystem;
        }

        public void Execute()
        {
            _audioSystem.TurnOff();
        }

        public void Undo()
        {
            _audioSystem.TurnOn();
        }
    }

    public class RemoteControl
    {
        private ICommand _onCommand;
        private ICommand _offCommand;
        private ICommand _lastCommand;

        public void SetCommands(ICommand onCommand, ICommand offCommand)
        {
            _onCommand = onCommand;
            _offCommand = offCommand;
        }

        public void PressOnButton()
        {
            if (_onCommand == null)
            {
                Console.WriteLine("Ошибка: команда включения не назначена.");
                return;
            }

            _onCommand.Execute();
            _lastCommand = _onCommand; 
        }

        public void PressOffButton()
        {
            if (_offCommand == null)
            {
                Console.WriteLine("Ошибка: команда выключения не назначена.");
                return;
            }

            _offCommand.Execute();
            _lastCommand = _offCommand; 
        }

        public void PressUndoButton()
        {
            if (_lastCommand != null)
            {
                _lastCommand.Undo();
            }
            else
            {
                Console.WriteLine("Нет последней команды для отмены.");
            }
        }
    }

    public class MacroCommand : ICommand
    {
        private readonly List<ICommand> _commands = new();

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
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
            foreach (var command in _commands)
            {
                command.Undo();
            }
        }
    }

    
    public abstract class Beverage
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
        }

        private void BoilWater()
        {
            Console.WriteLine("Кипячение воды...");
        }

        private void PourInCup()
        {
            Console.WriteLine("Наливание в чашку...");
        }

        protected abstract void Brew();
        protected abstract void AddCondiments();
    }

    public class Tea : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Заваривание чая...");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Добавление лимона...");
        }
    }

    public class Coffee : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Заваривание кофе...");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Добавление сахара и молока...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Часть 1: Тестирование паттерна "Команда"

            Light livingRoomLight = new Light();
            Television tv = new Television();
            AirConditioner ac = new AirConditioner();
            AudioSystem audioSystem = new AudioSystem();

            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);
            ICommand tvOn = new TelevisionOnCommand(tv);
            ICommand tvOff = new TelevisionOffCommand(tv);
            ICommand acOn = new AirConditionerOnCommand(ac);
            ICommand acOff = new AirConditionerOffCommand(ac);
            ICommand audioOn = new AudioSystemOnCommand(audioSystem);
            ICommand audioOff = new AudioSystemOffCommand(audioSystem);

            RemoteControl remote = new RemoteControl();

            remote.SetCommands(lightOn, lightOff);
            Console.WriteLine("Управление светом:");
            remote.PressOnButton();
            remote.PressOffButton();
            remote.PressUndoButton(); // Проверка отмены

            remote.SetCommands(tvOn, tvOff);
            Console.WriteLine("\nУправление телевизором:");
            remote.PressOnButton();
            remote.PressOffButton();
            remote.PressUndoButton();

 
            remote.SetCommands(acOn, acOff);
            Console.WriteLine("\nУправление кондиционером:");
            remote.PressOnButton();
            remote.PressOffButton();
            remote.PressUndoButton();


            remote.SetCommands(audioOn, audioOff);
            Console.WriteLine("\nУправление аудиосистемой:");
            remote.PressOnButton();
            remote.PressOffButton();
            remote.PressUndoButton(); 


            Console.WriteLine("\nВключение всех устройств:");
            MacroCommand allOn = new MacroCommand();
            allOn.AddCommand(lightOn);
            allOn.AddCommand(tvOn);
            allOn.AddCommand(acOn);
            allOn.AddCommand(audioOn);
            allOn.Execute();

            Console.WriteLine("Выключение всех устройств:");
