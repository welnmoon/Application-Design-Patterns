using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public interface IObserver
    {
        void Update(decimal usd, decimal eur);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class CurrencyExchange : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private decimal _usdRate;
        private decimal _eurRate;

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_usdRate, _eurRate);
            }
        }

        public void SetRates(decimal usd, decimal eur)
        {
            _usdRate = usd;
            _eurRate = eur;
            Notify();
        }
    }

    public class ScreenDisplay : IObserver
    {
        public void Update(decimal usd, decimal eur)
        {
            Console.WriteLine($"Текущий курс: USD = {usd}, EUR = {eur}");
        }
    }

    public class Logger : IObserver
    {
        public void Update(decimal usd, decimal eur)
        {
            Console.WriteLine($"[LOG] Изменение курсов: USD = {usd}, EUR = {eur}");
        }
    }

    public class MobileNotifier : IObserver
    {
        public void Update(decimal usd, decimal eur)
        {
            Console.WriteLine($"Мобильное уведомление: USD = {usd}, EUR = {eur}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            CurrencyExchange exchange = new CurrencyExchange();

            IObserver screen = new ScreenDisplay();
            IObserver logger = new Logger();
            IObserver mobileNotifier = new MobileNotifier();

            exchange.Attach(screen);
            exchange.Attach(logger);
            exchange.Attach(mobileNotifier);

            exchange.SetRates(83.50m, 92.30m);

            exchange.Detach(logger);

            exchange.SetRates(84.10m, 93.00m);
        }
    }
}
