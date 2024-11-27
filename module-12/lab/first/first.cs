using System;

class Program
{
    public class BookingStateMachine
    {
        public string CurrentState { get; private set; }

        public BookingStateMachine()
        {
            CurrentState = "Idle";
            Console.WriteLine("Система запущена. Текущее состояние: Idle");
        }

        public void SelectRoom()
        {
            if (CurrentState == "Idle")
            {
                CurrentState = "RoomSelected";
                Console.WriteLine("Номер выбран. Текущее состояние: RoomSelected");
            }
            else
            {
                Console.WriteLine("Невозможно выбрать номер в текущем состоянии.");
            }
        }

        public void ConfirmBooking()
        {
            if (CurrentState == "RoomSelected")
            {
                CurrentState = "BookingConfirmed";
                Console.WriteLine("Бронирование подтверждено. Текущее состояние: BookingConfirmed");
            }
            else
            {
                Console.WriteLine("Невозможно подтвердить бронирование в текущем состоянии.");
            }
        }

        public void PayBooking()
        {
            if (CurrentState == "BookingConfirmed")
            {
                CurrentState = "Paid";
                Console.WriteLine("Бронирование оплачено. Текущее состояние: Paid");
            }
            else
            {
                Console.WriteLine("Невозможно оплатить бронирование в текущем состоянии.");
            }
        }

        public void CancelBooking()
        {
            if (CurrentState == "RoomSelected" || CurrentState == "BookingConfirmed")
            {
                CurrentState = "BookingCancelled";
                Console.WriteLine("Бронирование отменено. Текущее состояние: BookingCancelled");
            }
            else
            {
                Console.WriteLine("Невозможно отменить бронирование в текущем состоянии.");
            }
        }

        public void Reset()
        {
            if (CurrentState == "Paid" || CurrentState == "BookingCancelled")
            {
                CurrentState = "Idle";
                Console.WriteLine("Система сброшена. Текущее состояние: Idle");
            }
            else
            {
                Console.WriteLine("Сброс недопустим в текущем состоянии.");
            }
        }
    }

    static void Main(string[] args)
    {
        var booking = new BookingStateMachine();

        booking.SelectRoom();
        booking.ConfirmBooking();
        booking.PayBooking();
        booking.Reset();

        booking.SelectRoom();
        booking.CancelBooking();
        booking.Reset();
    }
}
