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

        }
    }
}