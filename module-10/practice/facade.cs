using System;

public class RoomBookingSystem
{
    public void BookRoom()
    {
        Console.WriteLine("Room has been booked.");
    }

    public void CancelRoomBooking()
    {
        Console.WriteLine("Room booking has been canceled.");
    }
}

public class RestaurantSystem
{
    public void ReserveTable()
    {
        Console.WriteLine("Table has been reserved.");
    }

    public void OrderFood()
    {
        Console.WriteLine("Food has been ordered.");
    }
}

public class EventManagementSystem
{
    public void BookConferenceHall()
    {
        Console.WriteLine("Conference hall has been booked.");
    }

    public void OrderEquipment()
    {
        Console.WriteLine("Event equipment has been ordered.");
    }
}

public class CleaningService
{
    public void ScheduleCleaning()
    {
        Console.WriteLine("Cleaning has been scheduled.");
    }

    public void PerformCleaning()
    {
        Console.WriteLine("Cleaning in progress.");
    }
}

public class HotelFacade
{
    private RoomBookingSystem _roomBooking;
    private RestaurantSystem _restaurant;
    private EventManagementSystem _eventManagement;
    private CleaningService _cleaningService;

    public HotelFacade()
    {
        _roomBooking = new RoomBookingSystem();
        _restaurant = new RestaurantSystem();
        _eventManagement = new EventManagementSystem();
        _cleaningService = new CleaningService();
    }

    public void BookRoomWithServices()
    {
        _roomBooking.BookRoom();
        _restaurant.OrderFood();
        _cleaningService.ScheduleCleaning();
        Console.WriteLine("Room booked with food order and cleaning service.");
    }

    public void OrganizeEvent()
    {
        _eventManagement.BookConferenceHall();
        _eventManagement.OrderEquipment();
        _roomBooking.BookRoom();
        Console.WriteLine("Event organized with room booking and equipment order.");
    }

    public void ReserveTableWithTaxi()
    {
        _restaurant.ReserveTable();
        Console.WriteLine("Taxi has been ordered for restaurant reservation.");
    }

    public void CancelAllBookings()
    {
        _roomBooking.CancelRoomBooking();
        Console.WriteLine("All bookings have been canceled.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        HotelFacade hotel = new HotelFacade();

        hotel.BookRoomWithServices();
        hotel.OrganizeEvent();
        hotel.ReserveTableWithTaxi();
        hotel.CancelAllBookings();
    }
}
