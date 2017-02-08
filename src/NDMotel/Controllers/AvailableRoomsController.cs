using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NDMotel.Models;
using System.Data.SqlClient;
using NDMotel.Data;
 

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NDMotel.Controllers
{
    public class AvailableRoomsController : Controller
    {
        private readonly NDMotelContext _motelContext;
        
        
        public AvailableRoomsController(NDMotelContext context)
        {
            _motelContext = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //Booking logic goes here
            return View();
        }

        
        public IActionResult AvailableRooms(string Location, DateTime BookingStartDate, DateTime BookingEndDate, int numOfPeople )
        {
            //PropertyID Prop = (PropertyID) Enum.Parse(typeof(PropertyID), Location);
            
            var numOfRoomsNeeded = (numOfPeople / 2);
            var roomTypes = _motelContext.RoomTypes;                   
            //var motelProperties = from mp in _motelContext.MotelProperties
            //                      where mp.Location == Location
            //                      select mp.ID;

           int locationID = _motelContext.MotelProperties.Where(p => p.Location == Location).Select(p => p.ID).FirstOrDefault();

           var TotalRoomInventory = _motelContext.RoomInventory.Where(p => p.MotelPropertiesID == locationID).Select(p=>p);
           
            //var roomReservation = from rr in _motelContext.RoomReservations
            //                      join mp in _motelContext.MotelProperties
            //                      on rr.MotelPropertiesID equals mp.ID
            //                      where rr.MotelPropertiesID == locationID && rr.checkIn < BookingEndDate && rr.checkOut > BookingStartDate
            //                      select rr;
            var existingRoomReservation = _motelContext.RoomReservations.Where(p => p.MotelPropertiesID == locationID && p.checkIn < (BookingEndDate) && p.checkOut > (BookingStartDate)).Select(p => p);
            List<ReturnAvailibility> availableRooms = new List<ReturnAvailibility>();

            foreach (RoomInventory rt in TotalRoomInventory)
            {
                int totalConsumption = 0;

                if (existingRoomReservation != null)
                { 
                 var existingBookedRoomofSpecificType = existingRoomReservation.Where(p => p.RoomTypeID == rt.RoomTypeID);
                 totalConsumption = existingRoomReservation.Count();
                }

                if (rt.NumberOfRooms >= totalConsumption)
                {
                    // Room of specific type is not available 
                    //NOTE: Logic is limited to check against requested reservations only and does note check existing reservations against each other
                    //for validation of availibility
                    var description = roomTypes.Where(p => p.ID == rt.RoomTypeID).Select(p => p.RoomDescription).First();
                    var roomName = roomTypes.Where(p => p.ID == rt.RoomTypeID).Select(p => p.RoomName).First();

                    availableRooms.Add(new ReturnAvailibility {
                                                    Description = description,
                                                     //HighestPrice = rt.HighestPrice,
                                                     LowestPrice = rt.BestPrice,
                                                     Name = roomName
                                                    });  
                }
                
            }
            //List<BookRoom> BookRoom = new List<BookRoom>();
            BookRoom roomdetail = new BookRoom {
                RoomDetail = availableRooms,
                checkinDate = ( BookingStartDate),
                checkoutDate = (BookingEndDate),
                noofpeope = numOfPeople,
                locationid = locationID
               };

            //BookRoom.Add(roomdetail);

            return View(roomdetail);
            
        }
    }
}
