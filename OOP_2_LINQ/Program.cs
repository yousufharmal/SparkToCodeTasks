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
        // CASE 04 - VIEW ALL ROOMS
        // =========================================================
        static void ViewAllRooms(List<Room> rooms)
        {
            Console.WriteLine("=== ALL ROOMS ===");

            if (!rooms.Any())
            {
                Console.WriteLine("No rooms have been added yet.");
                return;
            }

            Console.WriteLine($"Total rooms: {rooms.Count()}\n");

            List<Room> orderedRooms = rooms
                .OrderBy(room => room.RoomNumber)
                .ToList();

            orderedRooms.ForEach(room => room.DisplayRoom());
        }
        
        // =========================================================
        // CASE 05 - VIEW ALL GUESTS
        // =========================================================
        static void ViewAllGuests(List<Guest> guests)
        {
            Console.WriteLine("=== ALL GUESTS ===");

            if (!guests.Any())
            {
                Console.WriteLine("No guests have been registered yet.");
                return;
            }

            Console.WriteLine($"Total guests: {guests.Count()}\n");

            List<Guest> orderedGuests = guests
                .OrderBy(guest => guest.GuestName)
                .ToList();

            orderedGuests.ForEach(guest => guest.DisplayGuest());
        }

        // =========================================================
        // CASE 06 - SEARCH AND FILTER ROOMS
        // =========================================================
        static void SearchAndFilterRooms(List<Room> rooms)
        {
            bool returnToMainMenu = false;

            while (!returnToMainMenu)
            {
                Console.WriteLine("=== SEARCH & FILTER ROOMS ===");
                Console.WriteLine("1. Show all available rooms");
                Console.WriteLine("2. Filter by room type");
                Console.WriteLine("3. Filter by maximum price");
                Console.WriteLine("4. Room price statistics");
                Console.WriteLine("0. Back");

                int choice = ReadInt("Enter your choice: ");
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        List<Room> availableRooms = rooms
                            .Where(room => room.IsAvailable)
                            .OrderBy(room => room.PricePerNight)
                            .ToList();

                        DisplayRoomResults(availableRooms);
                        break;

                    case 2:
                        string roomType = ReadRoomType();

                        List<Room> roomsByType = rooms
                            .Where(room =>
                                room.RoomType.Equals(
                                    roomType,
                                    StringComparison.OrdinalIgnoreCase))
                            .OrderBy(room => room.RoomNumber)
                            .ToList();

                        DisplayRoomResults(roomsByType);
                        break;

                    case 3:
                        double maximumPrice =
                            ReadPositiveDouble("Enter maximum price: OMR ");

                        List<Room> roomsByPrice = rooms
                            .Where(room =>
                                room.IsAvailable &&
                                room.PricePerNight <= maximumPrice)
                            .OrderBy(room => room.PricePerNight)
                            .ToList();

                        DisplayRoomResults(roomsByPrice);
                        break;

                    case 4:
                        DisplayRoomPriceStatistics(rooms);
                        break;

                    case 0:
                        returnToMainMenu = true;
                        break;

                    default:
                        Console.WriteLine("Invalid submenu choice.");
                        break;
                }

                if (!returnToMainMenu)
                {
                    Pause();
                }
            }
        }
        
        static void DisplayRoomResults(List<Room> matchingRooms)
        {
            if (!matchingRooms.Any())
            {
                Console.WriteLine("No rooms found for the selected criteria.");
                return;
            }

            Console.WriteLine($"Number of matching rooms: {matchingRooms.Count()}\n");

            matchingRooms.ForEach(room => room.DisplayRoom());
        }

        static void DisplayRoomPriceStatistics(List<Room> rooms)
        {
            if (!rooms.Any())
            {
                Console.WriteLine("No rooms have been added yet.");
                return;
            }

            Console.WriteLine($"Total rooms: {rooms.Count()}");
            Console.WriteLine(
                $"Available rooms: {rooms.Count(room => room.IsAvailable)}");
            Console.WriteLine(
                $"Average price: OMR {rooms.Average(room => room.PricePerNight):F2}");
            Console.WriteLine(
                $"Cheapest price: OMR {rooms.Min(room => room.PricePerNight):F2}");
            Console.WriteLine(
                $"Most expensive price: OMR {rooms.Max(room => room.PricePerNight):F2}");
        }
        
        // =========================================================
        // CASE 07 - GUEST AND BOOKING STATISTICS
        // =========================================================
        static void GuestAndBookingStatistics(
            List<Room> rooms,
            List<Guest> guests)
        {
            Console.WriteLine("=== GUEST & BOOKING STATISTICS ===");

            List<Guest> bookedGuests = guests
                .Where(guest => guest.RoomNumber != "Not Assigned")
                .ToList();

            Console.WriteLine($"Total registered guests: {guests.Count()}");
            Console.WriteLine($"Guests with active bookings: {bookedGuests.Count()}");
            Console.WriteLine($"Total rooms: {rooms.Count()}");
            Console.WriteLine(
                $"Currently booked rooms: {rooms.Count(room => !room.IsAvailable)}");

            if (!bookedGuests.Any())
            {
                Console.WriteLine("\nNo active bookings recorded.");
                return;
            }

            double averageNights = bookedGuests
                .Average(guest => guest.TotalNights);

            Console.WriteLine($"Average booked nights: {averageNights:F2}");

            List<Guest> topGuests = bookedGuests
                .OrderByDescending(guest => guest.CalculateTotalCost())
                .Take(3)
                .ToList();

            Console.WriteLine("\nTop 3 highest-spending guests:");

            topGuests.ForEach(guest =>
                Console.WriteLine(
                    $"{guest.GuestName} | Room {guest.RoomNumber} | " +
                    $"OMR {guest.CalculateTotalCost():F2}"));

            List<string> summaries = bookedGuests
                .Select(guest =>
                    $"{guest.GuestName} — Room {guest.RoomNumber} — " +
                    $"{guest.TotalNights} nights — " +
                    $"OMR {guest.CalculateTotalCost():F2}")
                .ToList();

            Console.WriteLine("\nActive booking summaries:");

            summaries.ForEach(summary => Console.WriteLine(summary));
        }
            
        // =========================================================
        // CASE 08 - UPDATE ROOM PRICE
        // =========================================================
        static void UpdateRoomPrice(List<Room> rooms)
        {
            Console.WriteLine("=== UPDATE ROOM PRICE ===");

            int roomNumber = ReadPositiveInt("Enter room number: ");

            Room room = rooms.FirstOrDefault(
                currentRoom => currentRoom.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            double newPrice = ReadPositiveDouble(
                "Enter new price per night: OMR ");

            double oldPrice = room.PricePerNight;
            room.PricePerNight = newPrice;

            Console.WriteLine("Room price updated successfully.");
            Console.WriteLine($"Old price: OMR {oldPrice:F2}");
            Console.WriteLine($"New price: OMR {room.PricePerNight:F2}");
        }
        
        // =========================================================
        // CASE 09 - GUEST LOOKUP BY NAME
        // =========================================================
        static void GuestLookupByName(List<Guest> guests)
        {
            Console.WriteLine("=== GUEST LOOKUP BY NAME ===");

            string searchText = ReadRequiredText(
                "Enter a full or partial guest name: ");

            List<Guest> matchingGuests = guests
                .Where(guest =>
                    guest.GuestName.Contains(
                        searchText,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!matchingGuests.Any())
            {
                Console.WriteLine("No guests matched that search.");
                return;
            }

            Console.WriteLine($"Matches found: {matchingGuests.Count()}\n");

            matchingGuests.ForEach(guest =>
                Console.WriteLine(
                    $"ID: {guest.GuestId} | Name: {guest.GuestName} | " +
                    $"Room: {guest.RoomNumber}"));
        }
        
        // =========================================================
        // CASE 10 - ROOM TYPE BREAKDOWN REPORT
        // =========================================================
        static void RoomTypeBreakdownReport(List<Room> rooms)
        {
            Console.WriteLine("=== ROOM TYPE BREAKDOWN REPORT ===");

            string[] roomTypes = { "Single", "Double", "Suite" };

            roomTypes.ToList().ForEach(roomType =>
            {
                int typeCount = rooms.Count(room =>
                    room.RoomType.Equals(
                        roomType,
                        StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"\n{roomType} rooms: {typeCount}");

                if (typeCount == 0)
                {
                    Console.WriteLine("Average price: N/A");
                }
                else
                {
                    double typeAverage = rooms
                        .Where(room =>
                            room.RoomType.Equals(
                                roomType,
                                StringComparison.OrdinalIgnoreCase))
                        .Average(room => room.PricePerNight);

                    Console.WriteLine(
                        $"Average price: OMR {typeAverage:F2}");
                }
            });

            if (rooms.Any())
            {
                Console.WriteLine(
                    $"\nOverall average price: OMR " +
                    $"{rooms.Average(room => room.PricePerNight):F2}");
            }
            else
            {
                Console.WriteLine("\nOverall average price: N/A");
            }
        }
        
        // =========================================================
        // CASE 11 - CHECK OUT A GUEST
        // =========================================================
        static void CheckOutGuest(
            List<Room> rooms,
            List<Guest> guests)
        {
            Console.WriteLine("=== CHECK OUT A GUEST ===");

            string guestId = ReadRequiredText(
                "Enter guest ID to check out: ").ToUpper();

            Guest guest = guests.FirstOrDefault(g =>
                g.GuestId.Equals(
                    guestId,
                    StringComparison.OrdinalIgnoreCase));

            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            if (guest.RoomNumber == "Not Assigned")
            {
                Console.WriteLine("This guest has no active booking.");
                return;
            }

            int bookedRoomNumber;

            if (!int.TryParse(guest.RoomNumber, out bookedRoomNumber))
            {
                Console.WriteLine("The guest's room information is invalid.");
                return;
            }

            Room room = rooms.FirstOrDefault(r =>
                r.RoomNumber == bookedRoomNumber);

            if (room == null)
            {
                Console.WriteLine("The linked room could not be found.");
                return;
            }

            Console.WriteLine("\n=== FINAL BILL ===");
            Console.WriteLine($"Guest name: {guest.GuestName}");
            Console.WriteLine($"Room number: {room.RoomNumber}");
            Console.WriteLine($"Room type: {room.RoomType}");
            Console.WriteLine($"Check-in date: {guest.CheckInDate}");
            Console.WriteLine($"Total nights: {guest.TotalNights}");
            Console.WriteLine($"Price per night: OMR {guest.PricePerNight:F2}");
            Console.WriteLine(
                $"Total cost: OMR {guest.CalculateTotalCost():F2}");

            char confirmation = ReadYesOrNo(
                "\nConfirm checkout (Y/N): ");

            if (confirmation == 'N')
            {
                Console.WriteLine("Checkout cancelled. No changes were made.");
                return;
            }

            room.IsAvailable = true;
            guests.Remove(guest);

            bool roomIsNowAvailable = rooms.Any(r =>
                r.RoomNumber == room.RoomNumber &&
                r.IsAvailable);

            Console.WriteLine("\nCheckout completed successfully.");
            Console.WriteLine($"Guest checked out: {guest.GuestName}");
            Console.WriteLine($"Room {room.RoomNumber} available: {roomIsNowAvailable}");
            Console.WriteLine($"Updated room count: {rooms.Count()}");
            Console.WriteLine($"Updated guest count: {guests.Count()}");
        }

        // =========================================================
        // CASE 12 - REMOVE UNAVAILABLE ROOMS
        // =========================================================
        static void RemoveUnavailableRooms(
            List<Room> rooms,
            List<Guest> guests)
        {
            Console.WriteLine("=== REMOVE UNAVAILABLE ROOMS ===");

            List<Room> removableRooms = rooms
                .Where(room =>
                    !room.IsAvailable &&
                    !guests.Any(guest =>
                        guest.RoomNumber == room.RoomNumber.ToString()))
                .OrderBy(room => room.RoomNumber)
                .ToList();

            if (!removableRooms.Any())
            {
                Console.WriteLine(
                    "All unavailable rooms are currently occupied. " +
                    "No rooms can be decommissioned.");
                return;
            }

            Console.WriteLine("Rooms safe to remove:\n");

            removableRooms.ForEach(room =>
                Console.WriteLine(
                    $"Room {room.RoomNumber} | {room.RoomType} | " +
                    $"OMR {room.PricePerNight:F2}"));

            Console.WriteLine(
                $"\nNumber of removable rooms: {removableRooms.Count()}");

            char confirmation = ReadYesOrNo(
                "Confirm removal (Y/N): ");

            if (confirmation == 'N')
            {
                Console.WriteLine("Removal cancelled. No rooms were removed.");
                return;
            }

            int removedCount = rooms.RemoveAll(room =>
                !room.IsAvailable &&
                !guests.Any(guest =>
                    guest.RoomNumber == room.RoomNumber.ToString()));

            Console.WriteLine($"\nRooms removed: {removedCount}");
            Console.WriteLine($"Updated total room count: {rooms.Count()}");

            List<string> remainingRooms = rooms
                .OrderBy(room => room.RoomNumber)
                .Select(room =>
                    $"Room {room.RoomNumber} — {room.RoomType}")
                .ToList();

            Console.WriteLine("\nRemaining rooms:");

            if (!remainingRooms.Any())
            {
                Console.WriteLine("No rooms remain.");
            }
            else
            {
                remainingRooms.ForEach(item => Console.WriteLine(item));
            }
        }
        
        // =========================================================
        // CASE 13 - EXTEND GUEST STAY
        // =========================================================
        static void ExtendGuestStay(List<Guest> guests)
        {
            Console.WriteLine("=== EXTEND GUEST STAY ===");

            string guestId = ReadRequiredText("Enter guest ID: ").ToUpper();

            Guest guest = guests.FirstOrDefault(g =>
                g.GuestId.Equals(
                    guestId,
                    StringComparison.OrdinalIgnoreCase));

            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            if (guest.RoomNumber == "Not Assigned")
            {
                Console.WriteLine(
                    "This guest has no active booking to extend.");
                return;
            }

            int additionalNights = ReadPositiveInt(
                "Enter additional nights: ");

            guest.TotalNights += additionalNights;

            Console.WriteLine("Stay extended successfully.");
            Console.WriteLine($"Updated total nights: {guest.TotalNights}");
            Console.WriteLine(
                $"New total cost: OMR {guest.CalculateTotalCost():F2}");
        }
        
        // =========================================================
        // CASE 14 - HIGHEST REVENUE BOOKING
        // =========================================================
        static void HighestRevenueBooking(List<Guest> guests)
        {
            Console.WriteLine("=== HIGHEST REVENUE BOOKING ===");

            List<Guest> activeGuests = guests
                .Where(guest => guest.RoomNumber != "Not Assigned")
                .ToList();

            if (!activeGuests.Any())
            {
                Console.WriteLine("No active bookings recorded.");
                return;
            }

            var highestRevenueBooking = activeGuests
                .Select(guest => new
                {
                    Name = guest.GuestName,
                    RoomNumber = guest.RoomNumber,
                    TotalCost = guest.CalculateTotalCost()
                })
                .OrderByDescending(booking => booking.TotalCost)
                .Take(1)
                .FirstOrDefault();

            Console.WriteLine($"Guest name: {highestRevenueBooking.Name}");
            Console.WriteLine($"Room number: {highestRevenueBooking.RoomNumber}");
            Console.WriteLine(
                $"Total cost: OMR {highestRevenueBooking.TotalCost:F2}");
        }

        // =========================================================
        // CASE 15 - GUEST PAGINATION VIEWER
        // =========================================================
        static void GuestPaginationViewer(List<Guest> guests)
        {
            Console.WriteLine("=== GUEST PAGINATION VIEWER ===");

            if (!guests.Any())
            {
                Console.WriteLine("No guests have been registered yet.");
                return;
            }

            const int pageSize = 3;

            int totalGuests = guests.Count();
            int totalPages = (int)Math.Ceiling(
                totalGuests / (double)pageSize);

            int requestedPage = ReadPositiveInt("Enter page number: ");

            if (requestedPage > totalPages)
            {
                Console.WriteLine("That page does not exist.");
                return;
            }

            List<Guest> guestsOnPage = guests
                .OrderBy(guest => guest.GuestName)
                .Skip((requestedPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            Console.WriteLine(
                $"\nPage {requestedPage} of {totalPages}");
            Console.WriteLine(
                $"Showing {guestsOnPage.Count()} guest(s):\n");

            guestsOnPage.ForEach(guest => guest.DisplayGuest());
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