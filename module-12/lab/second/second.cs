using System;

class Program
{
    public class TicketRequestStateMachine
    {
        public string CurrentState { get; private set; }

        public TicketRequestStateMachine()
        {
            CurrentState = "Created";
            Console.WriteLine("Заявка создана. Текущее состояние: Created");
        }

        public void SendToClient()
        {
            if (CurrentState == "Created")
            {
                CurrentState = "AwaitingPayment";
                Console.WriteLine("Заявка отправлена клиенту. Текущее состояние: AwaitingPayment");
            }
            else
            {
                Console.WriteLine("Действие недопустимо в текущем состоянии.");
            }
        }

        public void MarkAsPaid()
        {
            if (CurrentState == "AwaitingPayment")
            {
                CurrentState = "Paid";
                Console.WriteLine("Оплата получена. Текущее состояние: Paid");
            }
            else
            {
                Console.WriteLine("Действие недопустимо в текущем состоянии.");
            }
        }

        public void ConfirmBooking()
        {
            if (CurrentState == "Paid")
            {
                CurrentState = "Confirmed";
                Console.WriteLine("Бронирование подтверждено. Текущее состояние: Confirmed");
            }
            else
            {
                Console.WriteLine("Действие недопустимо в текущем состоянии.");
            }
        }

        public void CancelRequest()
        {
            if (CurrentState == "Created" || CurrentState == "AwaitingPayment")
            {
                CurrentState = "Cancelled";
                Console.WriteLine("Заявка отменена. Текущее состояние: Cancelled");
            }
            else
            {
                Console.WriteLine("Невозможно отменить заявку в текущем состоянии.");
            }
        }
    }

    static void Main(string[] args)
    {
        var ticketRequest = new TicketRequestStateMachine();

        ticketRequest.SendToClient();
        ticketRequest.MarkAsPaid();
        ticketRequest.ConfirmBooking();

        ticketRequest = new TicketRequestStateMachine();
        ticketRequest.SendToClient();
        ticketRequest.CancelRequest();
    }
}
