using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTradingSystem
{
    public interface IObserver
    {
        void Update(string stockSymbol, decimal price);
        List<string> GetSubscribedStocks();
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer, string stockSymbol);
        void RemoveObserver(IObserver observer, string stockSymbol);
        void NotifyObservers(string stockSymbol);
    }

    public class StockExchange : ISubject
    {
        private Dictionary<string, List<IObserver>> observers = new Dictionary<string, List<IObserver>>();
        private Dictionary<string, decimal> stockPrices = new Dictionary<string, decimal>();

        public void RegisterObserver(IObserver observer, string stockSymbol)
        {
            if (!observers.ContainsKey(stockSymbol))
            {
                observers[stockSymbol] = new List<IObserver>();
            }
            observers[stockSymbol].Add(observer);
            Console.WriteLine($"Наблюдатель подписан на {stockSymbol}");
        }

        public void RemoveObserver(IObserver observer, string stockSymbol)
        {
            if (observers.ContainsKey(stockSymbol))
            {
                observers[stockSymbol].Remove(observer);
                Console.WriteLine($"Наблюдатель отписан от {stockSymbol}");
            }
        }

        public void NotifyObservers(string stockSymbol)
        {
            if (observers.ContainsKey(stockSymbol))
            {
                foreach (var observer in observers[stockSymbol])
                {
                    observer.Update(stockSymbol, stockPrices[stockSymbol]);
                }
            }
        }

        public void SetStockPrice(string stockSymbol, decimal newPrice)
        {
            stockPrices[stockSymbol] = newPrice;
            Console.WriteLine($"Новая цена акции {stockSymbol}: {newPrice}");
            NotifyObservers(stockSymbol);
        }

        public decimal GetStockPrice(string stockSymbol)
        {
            return stockPrices.ContainsKey(stockSymbol) ? stockPrices[stockSymbol] : 0;
        }
    }

    public class Trader : IObserver
    {
        private string name;
        private List<string> subscribedStocks = new List<string>();

        public Trader(string name)
        {
            this.name = name;
        }

        public void Update(string stockSymbol, decimal price)
        {
            Console.WriteLine($"{name} получил обновление по акции {stockSymbol}: новая цена {price}");
        }

        public List<string> GetSubscribedStocks()
        {
            return subscribedStocks;
        }

        public void SubscribeStock(string stockSymbol)
        {
            subscribedStocks.Add(stockSymbol);
        }
    }

    public class TradingBot : IObserver
    {
        private string botName;
        private decimal buyThreshold;
        private decimal sellThreshold;
        private List<string> subscribedStocks = new List<string>();

        public TradingBot(string botName, decimal buyThreshold, decimal sellThreshold)
        {
            this.botName = botName;
            this.buyThreshold = buyThreshold;
            this.sellThreshold = sellThreshold;
        }

        public void Update(string stockSymbol, decimal price)
        {
            if (price <= buyThreshold)
            {
                Console.WriteLine($"{botName}: Покупаю акцию {stockSymbol} по цене {price}");
            }
            else if (price >= sellThreshold)
            {
                Console.WriteLine($"{botName}: Продаю акцию {stockSymbol} по цене {price}");
            }
            else
            {
                Console.WriteLine($"{botName}: Ожидаю изменения цены для {stockSymbol}");
            }
        }

        public List<string> GetSubscribedStocks()
        {
            return subscribedStocks;
        }

        public void SubscribeStock(string stockSymbol)
        {
            subscribedStocks.Add(stockSymbol);
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            StockExchange stockExchange = new StockExchange();

            Trader trader1 = new Trader("Трейдер 1");
            TradingBot bot1 = new TradingBot("Робот 1", 100, 200);

            trader1.SubscribeStock("AAPL");
            bot1.SubscribeStock("AAPL");
            bot1.SubscribeStock("GOOGL");

            stockExchange.RegisterObserver(trader1, "AAPL");
            stockExchange.RegisterObserver(bot1, "AAPL");
            stockExchange.RegisterObserver(bot1, "GOOGL");

            stockExchange.SetStockPrice("AAPL", 150);
            stockExchange.SetStockPrice("GOOGL", 250);

            await Task.Delay(2000);
            stockExchange.SetStockPrice("AAPL", 95);
            await Task.Delay(2000);
            stockExchange.SetStockPrice("GOOGL", 180);

            stockExchange.RemoveObserver(trader1, "AAPL");
            await Task.Delay(2000);
            stockExchange.SetStockPrice("AAPL", 90);
        }
    }
}
