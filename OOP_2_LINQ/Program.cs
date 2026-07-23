using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_2_LINQ
{
    
    class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }

        public Room(int roomNumber, string roomType, double pricePerNight, bool isAvailable = true)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
        }

        public void DisplayRoom()
        {
            string status = IsAvailable ? "Available" : "Booked";

            Console.WriteLine(
                $"Room: {RoomNumber} | Type: {RoomType} | " +
                $"Price: OMR {PricePerNight:F2} | Status: {status}");
        }
    }
    
    class Guest
    {
        public string GuestId { get; set; }
        public string GuestName { get; set; }
        public string RoomNumber { get; set; }
        public string CheckInDate { get; set; }
        public int TotalNights { get; set; }

        
        public double PricePerNight { get; set; }

        public Guest(
            string guestId,
            string guestName,
            string roomNumber,
            string checkInDate,
            int totalNights)
        {
            GuestId = guestId;
            GuestName = guestName;
            RoomNumber = roomNumber;
            CheckInDate = checkInDate;
            TotalNights = totalNights;
            PricePerNight = 0;
        }

        public void DisplayGuest()
        {
            Console.WriteLine(
                $"ID: {GuestId} | Name: {GuestName} | Room: {RoomNumber} | " +
                $"Check-in: {CheckInDate} | Nights: {TotalNights}");
        }

        public double CalculateTotalCost()
        {
            return TotalNights * PricePerNight;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>
            {
                new Room(101, "Single", 25.000),
                new Room(102, "Single", 28.000),
                new Room(201, "Double", 40.000),
                new Room(202, "Double", 45.000),
                new Room(301, "Suite", 80.000),
                new Room(302, "Suite", 95.000)
            };

            List<Guest> guests = new List<Guest>();

            bool running = true;

            while (running)
            {
                DisplayMainMenu();
                int choice = ReadInt("Enter your choice: ");

                Console.WriteLine();
                
                switch (choice)
                {
                    case 1:
                        AddNewRoom(rooms);
                        break;
                    
                    case 2:
                        RegisterNewGuest(guests);
                        break;
                    
                    case 3:
                        BookRoomForGuest(rooms, guests);
                        break;
                    /*
                    case 4:
                        ViewAllRooms(rooms);
                        break;

                    case 5:
                        ViewAllGuests(guests);
                        break;

                    case 6:
                        SearchAndFilterRooms(rooms);
                        break;

                    case 7:
                        GuestAndBookingStatistics(rooms, guests);
                        break;

                    case 8:
                        UpdateRoomPrice(rooms);
                        break;

                    case 9:
                        GuestLookupByName(guests);
                        break;

                    case 10:
                        RoomTypeBreakdownReport(rooms);
                        break;

                    case 11:
                        CheckOutGuest(rooms, guests);
                        break;

                    case 12:
                        RemoveUnavailableRooms(rooms, guests);
                        break;

                    case 13:
                        ExtendGuestStay(guests);
                        break;

                    case 14:
                        HighestRevenueBooking(guests);
                        break;

                    case 15:
                        GuestPaginationViewer(guests);
                        break;

                    case 0:
                        running = false;
                        Console.WriteLine("Thank you for using the system.");
                        break;

                    default:
                        Console.WriteLine("Invalid menu choice.");
                        break;
                    */
                }
                
                    
                if (running)
                {
                    Pause();
                }
            }
        }
        
        // =========================================================
        // CASE 01 - ADD NEW ROOM
        // =========================================================
        static void AddNewRoom(List<Room> rooms)
        {
            Console.WriteLine("=== ADD NEW ROOM ===");

            int roomNumber = ReadPositiveInt("Enter room number: ");

            bool roomExists = rooms.Any(room => room.RoomNumber == roomNumber);

            if (roomExists)
            {
                Console.WriteLine("Error: A room with that number already exists.");
                return;
            }

            string roomType = ReadRoomType();
            double price = ReadPositiveDouble("Enter price per night: OMR ");

            Room newRoom = new Room(roomNumber, roomType, price, true);
            rooms.Add(newRoom);

            Console.WriteLine("\nRoom added successfully.");
            newRoom.DisplayRoom();
            Console.WriteLine($"Updated total room count: {rooms.Count()}");
        }
        
        // =========================================================
        // CASE 02 - REGISTER NEW GUEST
        // =========================================================
        static void RegisterNewGuest(List<Guest> guests)
        {
            Console.WriteLine("=== REGISTER NEW GUEST ===");

            string guestName = ReadRequiredText("Enter guest name: ");
            string checkInDate = ReadRequiredText("Enter check-in date: ");
            int totalNights = ReadPositiveInt("Enter number of nights: ");

            int nextIdNumber = guests.Count() + 1;
            string guestId = $"G{nextIdNumber:D3}";

            // Prevent a repeated ID if guests were removed after checkout.
            while (guests.Any(guest => guest.GuestId == guestId))
            {
                nextIdNumber++;
                guestId = $"G{nextIdNumber:D3}";
            }

            Guest newGuest = new Guest(
                guestId,
                guestName,
                "Not Assigned",
                checkInDate,
                totalNights);

            guests.Add(newGuest);

            Console.WriteLine("\nGuest registered successfully.");
            newGuest.DisplayGuest();
        }
        
        // =========================================================
        // CASE 03 - BOOK A ROOM FOR A GUEST
        // =========================================================
        static void BookRoomForGuest(List<Room> rooms, List<Guest> guests)
        {
            Console.WriteLine("=== BOOK A ROOM FOR A GUEST ===");

            string guestId = ReadRequiredText("Enter guest ID: ").ToUpper();
            int roomNumber = ReadPositiveInt("Enter desired room number: ");

            Guest guest = guests.FirstOrDefault(
                g => g.GuestId.Equals(guestId, StringComparison.OrdinalIgnoreCase));

            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            Room room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            if (guest.RoomNumber != "Not Assigned")
            {
                Console.WriteLine(
                    $"This guest already has Room {guest.RoomNumber} assigned.");
                return;
            }

            if (!room.IsAvailable)
            {
                Console.WriteLine("Room is already booked.");
                return;
            }

            guest.RoomNumber = room.RoomNumber.ToString();
            guest.PricePerNight = room.PricePerNight;
            room.IsAvailable = false;

            Console.WriteLine("\nBooking confirmed.");
            Console.WriteLine($"Guest name: {guest.GuestName}");
            Console.WriteLine($"Room number: {room.RoomNumber}");
            Console.WriteLine($"Room type: {room.RoomType}");
            Console.WriteLine($"Price per night: OMR {room.PricePerNight:F2}");
            Console.WriteLine($"Total nights: {guest.TotalNights}");
            Console.WriteLine($"Total cost: OMR {guest.CalculateTotalCost():F2}");
        }

        
        // =========================================================
        // SIMPLE HELPER METHODS
        // =========================================================
        static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("HOTEL MANAGEMENT SYSTEM");
            Console.WriteLine("================================================");
            Console.WriteLine(" 1. Add New Room");
            Console.WriteLine(" 2. Register New Guest");
            Console.WriteLine(" 3. Book a Room for a Guest");
            Console.WriteLine(" 4. View All Rooms");
            Console.WriteLine(" 5. View All Guests");
            Console.WriteLine(" 6. Search & Filter Rooms");
            Console.WriteLine(" 7. Guest & Booking Statistics");
            Console.WriteLine(" 8. Update Room Price");
            Console.WriteLine(" 9. Guest Lookup by Name");
            Console.WriteLine("10. Room Type Breakdown Report");
            Console.WriteLine("11. Check Out a Guest");
            Console.WriteLine("12. Remove Unavailable Rooms");
            Console.WriteLine("13. Extend Guest Stay");
            Console.WriteLine("14. Highest Revenue Booking");
            Console.WriteLine("15. Guest Pagination Viewer");
            Console.WriteLine(" 0. Exit");
            Console.WriteLine("================================================");
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid whole number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number entered is too large.");
                }
            }
        }

        static int ReadPositiveInt(string message)
        {
            while (true)
            {
                int number = ReadInt(message);

                if (number > 0)
                {
                    return number;
                }

                Console.WriteLine("Please enter a number greater than zero.");
            }
        }

        static double ReadPositiveDouble(string message)
        {
            while (true)
            {
                Console.Write(message);

                try
                {
                    double number = double.Parse(Console.ReadLine());

                    if (number > 0)
                    {
                        return number;
                    }

                    Console.WriteLine(
                        "Please enter a number greater than zero.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number entered is too large.");
                }
            }
        }

        static string ReadRequiredText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                Console.WriteLine("This value cannot be empty.");
            }
        }

        static string ReadRoomType()
        {
            while (true)
            {
                string roomType = ReadRequiredText(
                    "Enter room type (Single/Double/Suite): ");

                if (roomType.Equals(
                    "Single",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return "Single";
                }

                if (roomType.Equals(
                    "Double",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return "Double";
                }

                if (roomType.Equals(
                    "Suite",
                    StringComparison.OrdinalIgnoreCase))
                {
                    return "Suite";
                }

                Console.WriteLine(
                    "Invalid room type. Enter Single, Double, or Suite.");
            }
        }

        static char ReadYesOrNo(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine().Trim().ToUpper();

                if (input == "Y")
                {
                    return 'Y';
                }

                if (input == "N")
                {
                    return 'N';
                }

                Console.WriteLine("Please enter Y or N.");
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}