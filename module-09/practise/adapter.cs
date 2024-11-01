using System;

namespace PaymentSystem
{
    // Интерфейс для обработки платежей
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }

    // Реализация IPaymentProcessor для PayPal
    public class PayPalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing payment of ${amount:0.00} through PayPal.");
        }
    }

    // Сторонний платежный сервис Stripe с несовместимым интерфейсом
    public class StripePaymentService
    {
        public void MakeTransaction(double totalAmount)
        {
            Console.WriteLine($"Processing payment of ${totalAmount:0.00} through Stripe.");
        }
    }

    // Адаптер для StripePaymentService, реализующий IPaymentProcessor
    public class StripePaymentAdapter : IPaymentProcessor
    {
        private readonly StripePaymentService _stripeService;

        public StripePaymentAdapter(StripePaymentService stripeService)
        {
            _stripeService = stripeService;
        }

        public void ProcessPayment(double amount)
        {
            _stripeService.MakeTransaction(amount);
        }
    }

    // Дополнительный сторонний платежный сервис Square с другим интерфейсом
    public class SquarePaymentService
    {
        public void ProcessSquarePayment(double payment)
        {
            Console.WriteLine($"Processing payment of ${payment:0.00} through Square.");
        }
    }

    // Адаптер для SquarePaymentService, реализующий IPaymentProcessor
    public class SquarePaymentAdapter : IPaymentProcessor
    {
        private readonly SquarePaymentService _squareService;

        public SquarePaymentAdapter(SquarePaymentService squareService)
        {
            _squareService = squareService;
        }

        public void ProcessPayment(double amount)
        {
            _squareService.ProcessSquarePayment(amount);
        }
    }

    // Клиентский код для тестирования системы
    class Program
    {
        static void Main()
        {
            // Использование PayPal
            IPaymentProcessor paypalProcessor = new PayPalPaymentProcessor();
            paypalProcessor.ProcessPayment(50.00);

            // Использование Stripe через адаптер
            StripePaymentService stripeService = new StripePaymentService();
            IPaymentProcessor stripeProcessor = new StripePaymentAdapter(stripeService);
            stripeProcessor.ProcessPayment(75.00);

            // Использование Square через адаптер
            SquarePaymentService squareService = new SquarePaymentService();
            IPaymentProcessor squareProcessor = new SquarePaymentAdapter(squareService);
            squareProcessor.ProcessPayment(100.00);
        }
    }
}
