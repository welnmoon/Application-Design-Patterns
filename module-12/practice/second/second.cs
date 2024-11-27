using System;
using System.Collections.Generic;

class Program
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }

    public class Booking
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        public string Status { get; set; }
    }

    public class BookingSystem
    {
        private List<Event> events = new List<Event>();
        private List<Booking> bookings = new List<Booking>();

        public BookingSystem()
        {
            events.Add(new Event { ID = 1, Name = "Концерт", Date = DateTime.Now.AddDays(5), Location = "Алматы" });
            events.Add(new Event { ID = 2, Name = "Выставка", Date = DateTime.Now.AddDays(10), Location = "Нур-Султан" });
        }

        public void ViewEvents()
        {
            foreach (var ev in events)
            {
                Console.WriteLine($"ID: {ev.ID}, Название: {ev.Name}, Дата: {ev.Date.ToShortDateString()}, Место: {ev.Location}");
            }
        }

        public void RegisterUser(string name)
        {
            Console.WriteLine($"{name} успешно зарегистрирован как пользователь.");
        }

        public void BookEvent(User user, int eventId)
        {
            if (user.Role != "User")
            {
                Console.WriteLine("Только зарегистрированные пользователи могут бронировать мероприятия.");
                return;
            }

            var ev = events.Find(e => e.ID == eventId);
            if (ev != null)
            {
                bookings.Add(new Booking { ID = bookings.Count + 1, User = user, Event = ev, Status = "Active" });
                Console.WriteLine($"Мероприятие '{ev.Name}' забронировано пользователем {user.Name}.");
            }
            else
            {
                Console.WriteLine("Мероприятие с указанным ID не найдено.");
            }
        }

        public void CancelBooking(User user, int bookingId)
        {
            var booking = bookings.Find(b => b.ID == bookingId && b.User.ID == user.ID);
            if (booking != null)
            {
                booking.Status = "Cancelled";
                Console.WriteLine($"Бронирование ID {booking.ID} отменено.");
            }
            else
            {
                Console.WriteLine("Бронирование не найдено или у вас нет прав для отмены.");
            }
        }

        public void ManageEvents(User user)
        {
            if (user.Role != "Admin")
            {
                Console.WriteLine("Только администратор может управлять мероприятиями.");
                return;
            }

            Console.WriteLine("1. Добавить мероприятие");
            Console.WriteLine("2. Удалить мероприятие");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Введите название мероприятия: ");
                string name = Console.ReadLine();
                Console.Write("Введите дату (дд.мм.гггг): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите место: ");
                string location = Console.ReadLine();

                events.Add(new Event { ID = events.Count + 1, Name = name, Date = date, Location = location });
                Console.WriteLine("Мероприятие добавлено.");
            }
            else if (choice == 2)
            {
                Console.Write("Введите ID мероприятия для удаления: ");
                int id = int.Parse(Console.ReadLine());
                var ev = events.Find(e => e.ID == id);
                if (ev != null)
                {
                    events.Remove(ev);
                    Console.WriteLine("Мероприятие удалено.");
                }
                else
                {
                    Console.WriteLine("Мероприятие не найдено.");
                }
            }
        }

        public void ViewAllBookings(User user)
        {
            if (user.Role != "Admin")
            {
                Console.WriteLine("Только администратор может просматривать все бронирования.");
                return;
            }

            foreach (var booking in bookings)
            {
                Console.WriteLine($"ID: {booking.ID}, Пользователь: {booking.User.Name}, Мероприятие: {booking.Event.Name}, Статус: {booking.Status}");
            }
        }
    }

    static void Main(string[] args)
    {
        var system = new BookingSystem();
        var admin = new User { ID = 1, Name = "Admin", Role = "Admin" };
        var user = new User { ID = 2, Name = "User1", Role = "User" };
        var guest = new User { ID = 3, Name = "Guest", Role = "Guest" };

        system.ViewEvents();
        system.BookEvent(user, 1);
        system.CancelBooking(user, 1);
        system.ManageEvents(admin);
        system.ViewAllBookings(admin);
    }
}
