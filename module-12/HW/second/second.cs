using System;

class Program
{
    public class TicketMachine
    {
        public string CurrentState { get; private set; }

        public TicketMachine()
        {
            CurrentState = "Idle";
            Console.WriteLine("Автомат готов. Текущее состояние: Idle");
        }

        public void SelectTicket()
        {
            if (CurrentState == "Idle")
            {
                CurrentState = "WaitingForMoney";
                Console.WriteLine("Билет выбран. Ожидание внесения средств. Текущее состояние: WaitingForMoney");
            }
            else
            {
                Console.WriteLine("Действие невозможно в текущем состоянии.");
            }
        }

        public void InsertMoney()
        {
            if (CurrentState == "WaitingForMoney")
            {
                CurrentState = "MoneyReceived";
                Console.WriteLine("Деньги внесены. Текущее состояние: MoneyReceived");
            }
            else
            {
                Console.WriteLine("Действие невозможно в текущем состоянии.");
            }
        }

        public void DispenseTicket()
        {
            if (CurrentState == "MoneyReceived")
            {
                CurrentState = "TicketDispensed";
                Console.WriteLine("Билет выдан. Текущее состояние: TicketDispensed");
            }
            else
            {
                Console.WriteLine("Действие невозможно в текущем состоянии.");
            }
        }

        public void CancelTransaction()
        {
            if (CurrentState == "WaitingForMoney" || CurrentState == "MoneyReceived")
            {
                CurrentState = "TransactionCanceled";
                Console.WriteLine("Транзакция отменена. Текущее состояние: TransactionCanceled");
            }
            else
            {
                Console.WriteLine("Невозможно отменить транзакцию в текущем состоянии.");
            }
        }

        public void Reset()
        {
            if (CurrentState == "TransactionCanceled" || CurrentState == "TicketDispensed")
            {
                CurrentState = "Idle";
                Console.WriteLine("Автомат сброшен. Текущее состояние: Idle");
            }
            else
            {
                Console.WriteLine("Сброс недоступен в текущем состоянии.");
            }
        }
    }

    static void Main(string[] args)
    {
        var ticketMachine = new TicketMachine();

        ticketMachine.SelectTicket();
        ticketMachine.InsertMoney();
        ticketMachine.DispenseTicket();
        ticketMachine.Reset();

        ticketMachine.SelectTicket();
        ticketMachine.CancelTransaction();
        ticketMachine.Reset();
    }
}
