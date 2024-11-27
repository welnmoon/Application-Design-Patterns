using System;

class Program
{
    public class OrderStateMachine
    {
        public string CurrentState { get; private set; }

        public OrderStateMachine()
        {
            CurrentState = "Idle";
            Console.WriteLine("Система готова. Текущее состояние: Idle");
        }

        public void SelectCar()
        {
            if (CurrentState == "Idle")
            {
                CurrentState = "CarSelected";
                Console.WriteLine("Автомобиль выбран. Текущее состояние: CarSelected");
            }
            else
            {
                Console.WriteLine("Действие недопустимо в текущем состоянии.");
            }
        }

        public void ConfirmOrder()
        {
            if (CurrentState == "CarSelected")
            {
                CurrentState = "OrderConfirmed";
                Console.WriteLine("Заказ подтвержден. Текущее состояние: OrderConfirmed");
            }
            else
            {
                Console.WriteLine("Действие недопустимо в текущем состоянии.");
            }
        }

        public void CarArrives()
        {
            if (CurrentState == "OrderConfirmed")
            {
                CurrentState = "CarArrived";
                Console.WriteLine("Автомобиль прибыл. Текущее состояние: CarArrived");
            }
            else
            {
                Console.WriteLine("Действие недопустимо в текущем состоянии.");
            }
        }

        public void StartTrip()
        {
            if (CurrentState == "CarArrived")
            {
                CurrentState = "InTrip";
                Console.WriteLine("Поездка началась. Текущее состояние: InTrip");
            }
            else
            {
                Console.WriteLine("Действие недопустимо в текущем состоянии.");
            }
        }

        public void CompleteTrip()
        {
            if (CurrentState == "InTrip")
            {
                CurrentState = "TripCompleted";
                Console.WriteLine("Поездка завершена. Ожидание оплаты. Текущее состояние: TripCompleted");
            }
            else
            {
                Console.WriteLine("Действие недопустимо в текущем состоянии.");
            }
        }

        public void CancelOrder()
        {
            if (CurrentState == "CarSelected" || CurrentState == "OrderConfirmed" || CurrentState == "CarArrived")
            {
                CurrentState = "TripCancelled";
                Console.WriteLine("Заказ отменен. Текущее состояние: TripCancelled");
            }
            else
            {
                Console.WriteLine("Невозможно отменить заказ в текущем состоянии.");
            }
        }

        public void Reset()
        {
            if (CurrentState == "TripCompleted" || CurrentState == "TripCancelled")
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
        var order = new OrderStateMachine();

        order.SelectCar();      
        order.ConfirmOrder();   
        order.CarArrives();      
        order.StartTrip();      
        order.CompleteTrip();    
        order.Reset();          
    }
}
