using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystem
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
    }

    public class Room
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
    }

    public class Booking
    {
        public string User { get; set; }
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }

    public interface IHotelService
    {
        List<Hotel> SearchHotels(string location);
    }

    public class HotelService : IHotelService
    {
        private readonly List<Hotel> _hotels = new List<Hotel>();

        public void AddHotel(Hotel hotel) => _hotels.Add(hotel);

        public List<Hotel> SearchHotels(string location)
        {
            return _hotels.Where(h => h.Location.Contains(location)).ToList();
        }
    }

    public interface IBookingService
    {
        Booking CreateBooking(string user, Hotel hotel, Room room, DateTime checkIn, DateTime checkOut);
    }

    public class BookingService : IBookingService
    {
        public Booking CreateBooking(string user, Hotel hotel, Room room, DateTime checkIn, DateTime checkOut)
        {
            if (room.IsAvailable)
            {
                room.IsAvailable = false;
                var booking = new Booking
                {
                    User = user,
                    Hotel = hotel,
                    Room = room,
                    CheckIn = checkIn,
                    CheckOut = checkOut
                };
                Console.WriteLine($"Booking created for {user} at {hotel.Name}, Room {room.Number}");
                return booking;
            }
            else
            {
                Console.WriteLine("Room is not available.");
                return null;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var hotelService = new HotelService();
            var bookingService = new BookingService();

            var hotel = new Hotel { Name = "Grand Hotel", Location = "Downtown" };
            var room1 = new Room { Number = 101, Type = "Single", Price = 100m };
            var room2 = new Room { Number = 102, Type = "Double", Price = 150m };

            hotel.Rooms.Add(room1);
            hotel.Rooms.Add(room2);
            hotelService.AddHotel(hotel);

            var hotels = hotelService.SearchHotels("Downtown");
            var booking = bookingService.CreateBooking("John Doe", hotels.First(), room1, DateTime.Now, DateTime.Now.AddDays(3));
        }
    }
}
