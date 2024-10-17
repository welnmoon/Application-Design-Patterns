using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public interface IObserver
    {
        void Update(float temperature);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    public class WeatherStation : ISubject
    {
        private List<IObserver> observers;
        private float temperature;

        public WeatherStation()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature);
            }
        }

        public void SetTemperature(float newTemperature)
        {
            if (newTemperature < -100 || newTemperature > 100)
            {
                Console.WriteLine("Ошибка: Неправильное значение температуры.");
                return;
            }

            Console.WriteLine($"Изменение температуры: {newTemperature}°C");
            temperature = newTemperature;
            NotifyObservers();
        }
    }

    public class WeatherDisplay : IObserver
    {
        private string _name;

        public WeatherDisplay(string name)
        {
            _name = name;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"{_name} показывает новую температуру: {temperature}°C");
        }
    }

    public class EmailNotifier : IObserver
    {
        private string _emailAddress;

        public EmailNotifier(string emailAddress)
        {
            _emailAddress = emailAddress;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"Отправка email на {_emailAddress}: Новая температура: {temperature}°C");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();

            WeatherDisplay mobileApp = new WeatherDisplay("Мобильное приложение");
            WeatherDisplay digitalBillboard = new WeatherDisplay("Электронное табло");
            EmailNotifier emailNotifier = new EmailNotifier("example@example.com");

            weatherStation.RegisterObserver(mobileApp);
            weatherStation.RegisterObserver(digitalBillboard);
            weatherStation.RegisterObserver(emailNotifier);

            weatherStation.SetTemperature(25.0f);
            weatherStation.SetTemperature(30.0f);

            weatherStation.RemoveObserver(digitalBillboard);
            weatherStation.SetTemperature(28.0f);

            weatherStation.SetTemperature(120.0f);
        }
    }
}
