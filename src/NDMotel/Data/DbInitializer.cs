using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDMotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NDMotel.Models
{
    public class DbInitializer
    {
        public static void Initialize(NDMotelContext context)
        {
            context.Database.EnsureCreated();

            if (context.Guests.Any())
            {
                return;
            }

            var guests = new Guest[]
            {
                new Guest { FirstName="Nirav", LastName="Desai",Address="123 Address Ln, FakeCity, IL", ZipCode="12345", PhoneNumber="123-456-7890" },
                new Guest { FirstName="Test", LastName="Person",Address="123 Address Road, FakeCity, IL", ZipCode="12345", PhoneNumber="321-456-7890" }
            };
            foreach (Guest guest in guests)
            {
                context.Guests.Add(guest);
            }

            context.SaveChanges();

            var roomType = new RoomType[]
            {
                new RoomType { RoomDescription="Spacious King Size Bed Room",RoomName="King" },
                new RoomType { RoomDescription="Spacious Smoking King Size Bed Room",RoomName="KingSM" },
                new RoomType { RoomDescription="Spacious Queen Size Bed Room",RoomName="Queen" },
                new RoomType { RoomDescription="Spacious  Smoking Queen Size Bed Room",RoomName="QueenSM" },
                new RoomType { RoomDescription="Spacious Suite with King Size Bed and Jacuzzi",RoomName="Suite" },
                new RoomType { RoomDescription="Spacious 2 Full Size Bed Room",RoomName="Full" }
            };

            foreach(RoomType RT in roomType)
            {
                context.RoomTypes.Add(RT);
            }

            context.SaveChanges();

            var motelProperties = new MotelProperties[]
            {
                new MotelProperties {Location = "Des Plaines", Address = "123 Des Plaines St., Des Plaines, IL 60016" },
                new MotelProperties {Location = "Chicago", Address = "123 Chicago Ln., Chicago, IL 60003" },
                new MotelProperties {Location = "Bartlett", Address = "123 Bartlett St., Bartlett, IL 60103" }
            };

            foreach (MotelProperties MP in motelProperties)
            {
                context.MotelProperties.Add(MP);
            }

            context.SaveChanges();

            var roomReservation = new RoomReservation[]
            {
                new RoomReservation {RoomTypeID = 1, GuestID=1, MotelPropertiesID = 1, checkIn=DateTime.Parse("02-02-2017"), checkOut=DateTime.Parse("02-03-2017") },
                new RoomReservation {RoomTypeID = 3, GuestID=2, MotelPropertiesID = 1, checkIn=DateTime.Parse("02-02-2017"), checkOut=DateTime.Parse("02-03-2017") }
            };

            foreach(RoomReservation RR in roomReservation)
            {
                context.RoomReservations.Add(RR);
            }

            context.SaveChanges();

            var roomInventory = new RoomInventory[]
            {
                new RoomInventory {RoomTypeID = 1, MotelPropertiesID = 1, HighestPrice = 70, BestPrice = 50, NumberOfRooms = 5 },
                new RoomInventory {RoomTypeID = 2, MotelPropertiesID = 1, HighestPrice = 80, BestPrice = 60, NumberOfRooms = 5 },
                new RoomInventory {RoomTypeID = 3, MotelPropertiesID = 1, HighestPrice = 70, BestPrice = 50, NumberOfRooms = 5 },
                new RoomInventory {RoomTypeID = 4, MotelPropertiesID = 1, HighestPrice = 70, BestPrice = 50, NumberOfRooms = 5 },
                new RoomInventory {RoomTypeID = 5, MotelPropertiesID = 1, HighestPrice = 100, BestPrice = 80, NumberOfRooms = 5 },
                new RoomInventory {RoomTypeID = 6, MotelPropertiesID = 1, HighestPrice = 60, BestPrice = 30, NumberOfRooms = 5 }
            };

            foreach(RoomInventory RI in roomInventory)
            {
                context.RoomInventory.Add(RI);
            }

            context.SaveChanges();

            
        }
    }
}
