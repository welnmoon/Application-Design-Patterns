using System;

namespace Strategy
{
    public interface IPaymentStrategy
    {
        void Pay();
    }

    public class PayPal : IPaymentStrategy
    {
        private string _email;

        public PayPal(string email)
        {
            _email = email;
        }

        public void Pay()
        {
            Console.WriteLine($"Оплата через PayPal с аккаунта: {_email}");
        }
    }

    public class Crypto : IPaymentStrategy
    {
        private string _walletAddress;

        public Crypto(string walletAddress)
        {
            _walletAddress = walletAddress;
        }

        public void Pay()
        {
            Console.WriteLine($"Оплата через криптовалюту с кошелька: {_walletAddress}");
        }
    }

    public class BankCard : IPaymentStrategy
    {
        private string _cardNumber;

        public BankCard(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public void Pay()
        {
            Console.WriteLine($"Оплата через банковскую карту с номером: {_cardNumber}");
        }
    }

    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        public PaymentContext(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void SetStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void ExecutePayment()
        {
            _paymentStrategy.Pay();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            IPaymentStrategy paypalStrategy = new PayPal("user@example.com");
            IPaymentStrategy cryptoStrategy = new Crypto("0xABC123...XYZ");
            IPaymentStrategy bankCardStrategy = new BankCard("1234 5678 9123 4567");

            // Создаем контекст и передаем начальную стратегию оплаты
            PaymentContext context = new PaymentContext(paypalStrategy);
            context.ExecutePayment();  // Оплата через PayPal

            // Меняем стратегию на оплату через криптовалюту
            context.SetStrategy(cryptoStrategy);
            context.ExecutePayment();  // Оплата через криптовалюту

            // Меняем стратегию на оплату через банковскую карту
            context.SetStrategy(bankCardStrategy);
            context.ExecutePayment();  // Оплата через банковскую карту
        }
    }
}
